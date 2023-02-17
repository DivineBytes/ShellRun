namespace ShellRun.Base
{
    /// <summary>
    /// The <see cref="CommandBase"/> class.
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// Start the shell command.
        /// </summary>
        /// <returns>The <see cref="bool"/> result.</returns>
        public abstract bool Start();
    }
}