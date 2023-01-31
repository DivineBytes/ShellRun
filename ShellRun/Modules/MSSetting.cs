using ShellRun.Utilities;
using System;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="MSSetting"/>.
    /// </summary>
    public class MSSetting : CommandContainer
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
        /// The <see cref="MSSetting"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="command">The command.</param>
        public MSSetting(string name, string command) : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Cannot be null.");
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Cannot be null.");
            }

            Name = name;
            Command = command;
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
        /// The open.
        /// </summary>
        public override bool Open()
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
