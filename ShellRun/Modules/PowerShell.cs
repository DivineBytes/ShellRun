using ShellRun.Base;
using ShellRun.Utilities;
using System;
using System.IO;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="PowerShell"/> class.
    /// </summary>
    /// <seealso cref="ShellRun.Base.ScriptBase"/>
    public class PowerShell : ScriptBase
    {
        /// <summary>
        /// The command prefix.
        /// </summary>
        public const string CommandPrefix = "-NoProfile -ExecutionPolicy ByPass -File";

        /// <summary>
        /// The executable file.
        /// </summary>
        public const string Executable = "powershell.exe";

        /// <summary>
        /// The 64-bit directory.
        /// </summary>
        /// <value>The directory64 bit.</value>
        /// <remarks>Example: C:\Windows\System32\WindowsPowerShell\v1.0\</remarks>
        public static DirectoryInfo Directory64Bit
        {
            get
            {
                return new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "WindowsPowerShell\\v1.0"));
            }
        }

        /// <summary>
        /// The 32-bit directory.
        /// </summary>
        /// <value>The directory32 bit.</value>
        /// <remarks>Example: C:\Windows\SysWOW64\WindowsPowerShell\v1.0\</remarks>
        public static DirectoryInfo Directory32Bit
        {
            get
            {
                return new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SysWOW64\\WindowsPowerShell\\v1.0"));
            }
        }

        /// <summary>
        /// The PowerShell 64-Bit file info.
        /// </summary>
        /// <value>The powershell64.</value>
        public static FileInfo Powershell64
        {
            get
            {
                string fullPath = Path.Combine(Directory64Bit.FullName, Executable);
                return new FileInfo(fullPath);
            }
        }

        /// <summary>
        /// The PowerShell 32-Bit file info.
        /// </summary>
        /// <value>The powershell32.</value>
        public static FileInfo Powershell32
        {
            get
            {
                string fullPath = Path.Combine(Directory32Bit.FullName, Executable);
                return new FileInfo(fullPath);
            }
        }

        /// <summary>
        /// Start the PowerShell file.
        /// </summary>
        /// <param name="powershellFile">The PowerShell file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="runAsAdmin">The run as admin.</param>
        /// <param name="createNoWindow">The create no window.</param>
        /// <param name="prefix">The prefix command.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// powershellFile - Cannot be null or empty. or prefix - Cannot be null or empty.
        /// </exception>
        public static bool Start(string powershellFile, string arguments = "", bool runAsAdmin = false, bool createNoWindow = false, string prefix = CommandPrefix)
        {
            if (string.IsNullOrEmpty(powershellFile))
            {
                throw new ArgumentNullException(nameof(powershellFile), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentNullException(nameof(prefix), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            string command;
            if (string.IsNullOrEmpty(arguments))
            {
                command = $"{prefix} \"{powershellFile}\"";
            }
            else
            {
                command = $"{prefix} \"{powershellFile}\" \"{arguments}\"";
            }

            return ProcessUtilities.StartProcess(Executable, command, runAsAdmin, createNoWindow, true);
        }
    }
}