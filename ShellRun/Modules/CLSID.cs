using ShellRun.Base;
using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="CLSID"/> class.
    /// </summary>
    /// <seealso cref="ShellRun.Base.CommandBase"/>
    public class CLSID : CommandBase
    {
        /// <summary>
        /// The empty <see cref="CLSID"/>.
        /// </summary>
        public static CLSID Empty = new CLSID();

        /// <summary>
        /// The shell command prefix.
        /// </summary>
        public const string ShellCommand = "shell:::";

        /// <summary>
        /// The <see cref="CLSID"/>.
        /// </summary>
        private CLSID()
        {
            GUIDS = new List<string>();
            Name = string.Empty;
        }

        /// <summary>
        /// The <see cref="CLSID"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="guid">The guid.</param>
        /// <exception cref="System.ArgumentNullException">
        /// name - Cannot be null. or guid - Cannot be null.
        /// </exception>
        public CLSID(string name, List<string> guid) : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (guid == null)
            {
                throw new ArgumentNullException(nameof(guid), Constants.ExceptionMessages.CannotBeNull);
            }

            Name = name;
            GUIDS = guid;
        }

        /// <summary>
        /// The name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// The GUIDS.
        /// </summary>
        /// <value>The guids.</value>
        public List<string> GUIDS { get; private set; }

        /// <summary>
        /// The count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return GUIDS.Count;
            }
        }

        /// <summary>
        /// The command.
        /// </summary>
        /// <value>The command.</value>
        public string Command
        {
            get
            {
                return CreateCommand(this);
            }
        }

        /// <summary>
        /// The GUID.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string GUID
        {
            get
            {
                return GUIDS[0];
            }
        }

#pragma warning disable 1591

        public override bool Start()
        {
            if (!string.IsNullOrEmpty(GUID))
            {
                return Open(GUID);
            }

            return false;
        }

        /// <summary>
        /// The create command.
        /// </summary>
        /// <param name="guid">The guid.</param>
        /// <returns>The <see cref="string"/> result.</returns>
        public static string CreateCommand(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                return ShellCommand + guid;
            }

            return ShellCommand;
        }

        /// <summary>
        /// The create command.
        /// </summary>
        /// <param name="clsid">The clsid.</param>
        /// <returns>The <see cref="string"/> result.</returns>
        public static string CreateCommand(CLSID clsid)
        {
            if (clsid != null)
            {
                return CreateCommand(clsid.GUID);
            }

            return ShellCommand;
        }

        /// <summary>
        /// Open the GUID.
        /// </summary>
        /// <param name="guid">The guid.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        public static bool Open(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                string argument = CreateCommand(guid);

                ProcessStartInfo processStartInfo = new ProcessStartInfo(FileExplorerUtilities.Explorer)
                {
                    Arguments = argument,
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
                };

                return ProcessUtilities.StartProcess(processStartInfo);
            }

            return false;
        }

        /// <summary>
        /// Open the <see cref="CLSID"/>.
        /// </summary>
        /// <param name="clsid">The clsid.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        public static bool Open(CLSID clsid)
        {
            if (clsid != null)
            {
                Open(clsid.GUID);
            }

            return false;
        }
    }
}