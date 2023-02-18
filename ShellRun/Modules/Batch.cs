using ShellRun.Base;
using ShellRun.Properties;
using ShellRun.Utilities;
using System;
using System.IO;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="Batch" /> class.
    /// </summary>
    /// <seealso cref="ShellRun.Base.ScriptBase" />
    public class Batch : ScriptBase
    {
        /// <summary>
        /// The executable file.
        /// </summary>
        public const string Executable = "cmd.exe";

        /// <summary>
        /// The Command Prompt file path.
        /// </summary>
        /// <value>
        /// The command prompt.
        /// </value>
        public static string CommandPrompt
        {
            get
            {
                string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), Executable);
                return fullPath;
            }
        }

        /// <summary>
        /// Start the batch file.
        /// </summary>
        /// <param name="batchFile">The batch file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="runAsAdmin">The run as admin.</param>
        /// <param name="createNoWindow">The create no window.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        /// <exception cref="System.ArgumentNullException">batchFile - Cannot be null or empty.</exception>
        public static bool Start(string batchFile, string arguments = "", bool runAsAdmin = false, bool createNoWindow = false)
        {
            if (string.IsNullOrEmpty(batchFile))
            {
                throw new ArgumentNullException(nameof(batchFile), Settings.Default.Arg_CannotBeNullOrEmpty);
            }

            return ProcessUtilities.StartProcess(batchFile, arguments, runAsAdmin, createNoWindow, true);
        }
    }
}