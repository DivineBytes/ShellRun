using ShellRun.Base;
using ShellRun.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="ControlPanelApplet"/>.
    /// </summary>
    /// <seealso cref="ShellRun.Base.CommandBase"/>
    public class ControlPanelApplet : CommandBase
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
        /// <exception cref="System.ArgumentNullException">
        /// name - Cannot be null. or commands - Cannot be null.
        /// </exception>
        public ControlPanelApplet(string name, List<string> commands) : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (commands == null && commands.Count > 0)
            {
                throw new ArgumentNullException(nameof(commands), Constants.ExceptionMessages.CannotBeNull);
            }

            Name = name;
            Commands = commands;
        }

        /// <summary>
        /// The name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// The commands.
        /// </summary>
        /// <value>The commands.</value>
        public List<string> Commands { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        /// <value>The command.</value>
        public string Command
        {
            get
            {
                return Commands[0];
            }
        }

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