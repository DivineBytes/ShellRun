using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="Shell"/>.
    /// </summary>
    public class Shell : CommandContainer
    {
        /// <summary>
        /// The empty <see cref="Shell"/>.
        /// </summary>
        public static Shell Empty = new Shell();
        public const string ShellCommand = "shell:";

        /// <summary>
        /// The <see cref="Shell"/>.
        /// </summary>
        private Shell()
        {
            Description = string.Empty;
            Name = string.Empty;
            GUID = string.Empty;
        }

        /// <summary>
        /// The <see cref="Shell"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="guid">The guid.</param>
        /// <param name="description">The description.</param>
        /// <param name="path">The path.</param>
        public Shell(string name, string guid = "", string description = "", string path = "") : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Cannot be null.");
            }

            if (guid == null)
            {
                throw new ArgumentNullException(nameof(guid), "Cannot be null.");
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description), "Cannot be null.");
            }

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path), "Cannot be null.");
            }

            Name = name;
            GUID = guid;
            Description = description;
            Path = path;
        }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The path.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The guid.
        /// </summary>
        public string GUID { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command
        {
            get
            {
                return CreateCommand(this);
            }
        }

        /// <summary>
        /// The create command.
        /// </summary>
        /// <param name="shell">The shell.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static string CreateCommand(Shell shell)
        {
            if (shell == null)
            {
                throw new ArgumentNullException(nameof(shell), "Cannot be null.");
            }

            return string.Format("\"{0}{1}\"", ShellCommand, shell.Name);
        }

        /// <summary>
        /// The open.
        /// </summary>
        public override bool Open()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(Command)
            {
                UseShellExecute = true
            };

            return ProcessUtilities.StartProcess(processStartInfo);
        }
    }
}