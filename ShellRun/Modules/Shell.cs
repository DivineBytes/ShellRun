using ShellRun.Base;
using ShellRun.Utilities;
using System;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="Shell" />.
    /// </summary>
    /// <seealso cref="ShellRun.Base.CommandBase" />
    public class Shell : CommandBase
    {
        /// <summary>
        /// The empty <see cref="Shell" />.
        /// </summary>
        public static Shell Empty = new Shell();

        /// <summary>
        /// The shell command prefix.
        /// </summary>
        public const string ShellCommand = "shell:";

        /// <summary>
        /// The <see cref="Shell" />.
        /// </summary>
        private Shell()
        {
            Description = string.Empty;
            Name = string.Empty;
            GUID = string.Empty;
        }

        /// <summary>
        /// The <see cref="Shell" />.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="guid">The guid.</param>
        /// <param name="description">The description.</param>
        /// <param name="path">The path.</param>
        /// <exception cref="System.ArgumentNullException">name - Cannot be null. or guid - Cannot be null. or description - Cannot be null. or
        /// path - Cannot be null.</exception>
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
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; private set; }

        /// <summary>
        /// The path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; private set; }

        /// <summary>
        /// The name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// The guid.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public string GUID { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public string Command
        {
            get
            {
                return CreateCommand(this);
            }
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="shell">The shell.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        /// <exception cref="System.ArgumentNullException">shell - Cannot be null.</exception>
        public static string CreateCommand(Shell shell)
        {
            if (shell == null)
            {
                throw new ArgumentNullException(nameof(shell), "Cannot be null.");
            }

            return string.Format("\"{0}{1}\"", ShellCommand, shell.Name);
        }

#pragma warning disable 1591

        public override bool Start()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(Command)
            {
                UseShellExecute = true
            };

            return ProcessUtilities.StartProcess(processStartInfo);
        }
    }
}