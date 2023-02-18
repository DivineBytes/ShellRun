using ShellRun.Base;
using ShellRun.Properties;
using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="MicrosoftManagementConsole" />.
    /// </summary>
    /// <seealso cref="ShellRun.Base.CommandBase" />
    public class MicrosoftManagementConsole : CommandBase
    {
        /// <summary>
        /// The empty <see cref="MicrosoftManagementConsole" />.
        /// </summary>
        public static MicrosoftManagementConsole Empty = new MicrosoftManagementConsole();

        /// <summary>
        /// The <see cref="Category" />.
        /// </summary>
        public class Category
        {
            /// <summary>
            /// The AD Configuration.
            /// </summary>
            public const string ADConfiguration = "AD Configuration";

            /// <summary>
            /// The disc.
            /// </summary>
            public const string Disc = "Disc";

            /// <summary>
            /// The file.
            /// </summary>
            public const string File = "File";

            /// <summary>
            /// The hardware.
            /// </summary>
            public const string Hardware = "Hardware";

            /// <summary>
            /// The network.
            /// </summary>
            public const string Network = "Network";

            /// <summary>
            /// None.
            /// </summary>
            public const string None = "None";

            /// <summary>
            /// The Phone / Modem.
            /// </summary>
            public const string PhoneModem = "Phone/Modem";

            /// <summary>
            /// The policy.
            /// </summary>
            public const string Policy = "Policy";

            /// <summary>
            /// The print.
            /// </summary>
            public const string Print = "Print";

            /// <summary>
            /// The remote access.
            /// </summary>
            public const string RemoteAccess = "Remote Access";

            /// <summary>
            /// The security.
            /// </summary>
            public const string Security = "Security";
        }

        /// <summary>
        /// The <see cref="MicrosoftManagementConsole" />.
        /// </summary>
        private MicrosoftManagementConsole()
        {
            Name = string.Empty;
            Command = string.Empty;
            Categorys = new List<string>();
        }

        /// <summary>
        /// The <see cref="MicrosoftManagementConsole" />.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="command">The command.</param>
        /// <param name="categorys">The categorys.</param>
        /// <exception cref="System.ArgumentNullException">
        /// name - Cannot be null.
        /// or
        /// command - Cannot be null.
        /// or
        /// categorys - Cannot be null.
        /// </exception>
        public MicrosoftManagementConsole(string name, string command, List<string> categorys) : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (categorys == null)
            {
                throw new ArgumentNullException(nameof(categorys), Constants.ExceptionMessages.CannotBeNull);
            }

            Name = name;
            Command = command;
            Categorys = categorys;
        }

        /// <summary>
        /// The name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public string Command { get; private set; }

        /// <summary>
        /// The category.
        /// </summary>
        /// <value>
        /// The categorys.
        /// </value>
        public List<string> Categorys { get; private set; }

#pragma warning disable 1591

        public override bool Start()
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