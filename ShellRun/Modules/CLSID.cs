using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="CLSID"/> class.
    /// </summary>
    public class CLSID : CommandContainer
    {
        public static CLSID Empty = new CLSID();
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
        public CLSID(string name, List<string> guid) : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Cannot be null.");
            }

            if (guid == null)
            {
                throw new ArgumentNullException(nameof(guid), "Cannot be null.");
            }

            Name = name;
            GUIDS = guid;
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The GUIDS.
        /// </summary>
        public List<string> GUIDS { get; private set; }

        /// <summary>
        /// The count.
        /// </summary>
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
        public string GUID
        {
            get
            {
                return GUIDS[0];
            }
        }

        /// <summary>
        /// The open.
        /// </summary>
        public override bool Open()
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
        public static string CreateCommand(CLSID clsid)
        {
            if (clsid != null)
            {
                return CreateCommand(clsid.GUID);
            }

            return ShellCommand;
        }

        /// <summary>
        /// The open.
        /// </summary>
        /// <param name="guid">The guid.</param>
        public static bool Open(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                string argument = CreateCommand(guid);

                ProcessStartInfo processStartInfo = new ProcessStartInfo("explorer.exe")
                {
                    Arguments = argument,
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
                };

                return ProcessUtilities.StartProcess(processStartInfo);
            }

            return false;
        }

        /// <summary>
        /// The open.
        /// </summary>
        /// <param name="clsid">The clsid.</param>
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
