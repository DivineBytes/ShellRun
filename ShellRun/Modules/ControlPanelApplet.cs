using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="ControlPanelApplet"/>.
    /// </summary>
    public class ControlPanelApplet : CommandContainer
    {
        /// <summary>
        /// The empty <see cref="ControlPanelApplet"/>.
        /// </summary>
        public static ControlPanelApplet Empty = new ControlPanelApplet();

        /// <summary>
        /// The <see cref="ControlPanelApplet"/>.
        /// </summary>
        private ControlPanelApplet()
        {
            Name = string.Empty;
            Commands = new List<string>();
        }

        /// <summary>
        /// The <see cref="ControlPanelApplet"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="commands">The commands.</param>
        public ControlPanelApplet(string name, List<string> commands) : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Cannot be null.");
            }

            if (commands == null && commands.Count > 0)
            {
                throw new ArgumentNullException(nameof(commands), "Cannot be null.");
            }

            Name = name;
            Commands = commands;
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The commands.
        /// </summary>
        public List<string> Commands { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command
        {
            get
            {
                return Commands[0];
            }
        }

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
