using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="MicrosoftManagementConsole"/>.
    /// </summary>
    public class MicrosoftManagementConsole : CommandContainer
    {
        /// <summary>
        /// The empty <see cref="MicrosoftManagementConsole"/>.
        /// </summary>
        public static MicrosoftManagementConsole Empty = new MicrosoftManagementConsole();

        /// <summary>
        /// The <see cref="Category"/>.
        /// </summary>
        public class Category
        {
            public const string ADConfiguration = "AD Configuration";
            public const string Disc = "Disc";
            public const string File = "File";
            public const string Hardware = "Hardware";
            public const string Network = "Network";
            public const string None = "None";
            public const string PhoneModem = "Phone/Modem";
            public const string Policy = "Policy";
            public const string Print = "Print";
            public const string RemoteAccess = "Remote Access";
            public const string Security = "Security";
        }

        /// <summary>
        /// The <see cref="MicrosoftManagementConsole"/>.
        /// </summary>
        private MicrosoftManagementConsole()
        {
            Name = string.Empty;
            Command = string.Empty;
            Categorys = new List<string>();
        }

        /// <summary>
        /// The <see cref="MicrosoftManagementConsole"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="command">The command.</param>
        /// <param name="categorys">The categorys.</param>
        public MicrosoftManagementConsole(string name, string command, List<string> categorys) : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Cannot be null.");
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Cannot be null.");
            }

            if (categorys == null)
            {
                throw new ArgumentNullException(nameof(categorys), "Cannot be null.");
            }

            Name = name;
            Command = command;
            Categorys = categorys;
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command { get; private set; }

        /// <summary>
        /// The category.
        /// </summary>
        public List<string> Categorys { get; private set; }

        /// <summary>
        /// The open.
        /// </summary>
        public override bool Open()
        {
            if (!string.IsNullOrEmpty(Command))
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("explorer.exe")
                {
                    Arguments = Command,
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System)
                };

                return ProcessUtilities.StartProcess(processStartInfo);
            }

            return false;
        }
    }
}
