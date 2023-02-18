using ShellRun.Base;
using ShellRun.Properties;
using ShellRun.Utilities;
using System;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="MSSetting"/>.
    /// </summary>
    public class MSSetting : CommandBase
    {
        /// <summary>
        /// The empty <see cref="MSSetting"/>.
        /// </summary>
        public static MSSetting Empty = new MSSetting();

        /// <summary>
        /// The <see cref="MSSetting"/>.
        /// </summary>
        private MSSetting()
        {
            Name = string.Empty;
            Command = string.Empty;
        }

        /// <summary>
        /// The <see cref="MSSetting" />.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="command">The command.</param>
        /// <exception cref="System.ArgumentNullException">
        /// name - Cannot be null.
        /// or
        /// command - Cannot be null.
        /// </exception>
        public MSSetting(string name, string command) : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), Settings.Default.Arg_CannotBeNull);
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), Settings.Default.Arg_CannotBeNull);
            }

            Name = name;
            Command = command;
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

#pragma warning disable 1591

        public override bool Start()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(Command)
                {
                    UseShellExecute = true
                };

                return ProcessUtilities.StartProcess(processStartInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}