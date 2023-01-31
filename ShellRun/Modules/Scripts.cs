using ShellRun.Utilities;
using System;
using System.ComponentModel;
using System.IO;

namespace ShellRun.Modules
{
    public class Scripts
    {
        /// <summary>
        /// The <see cref="VBScript"/> enum.
        /// </summary>
        public enum VBScript
        {
            // POP-UPS Disabled
            [Description("cscript.exe")]
            CScript = 0,

            // POP-UPS Enabled
            [Description("wscript.exe")]
            WScript = 1
        }

        /// <summary>
        /// The run vbscript.
        /// </summary>
        /// <param name="vbsFile">The vbs file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="vbscriptType">The vbscript type.</param>
        /// <param name="runAsAdmin">The run as admin.</param>
        /// <param name="createNoWindow">The create no window.</param>
        public static bool RunVBScript(string vbsFile, string arguments = "", VBScript vbscriptType = VBScript.CScript, bool runAsAdmin = false, bool createNoWindow = false)
        {
            if (vbsFile == null)
            {
                throw new ArgumentNullException(nameof(vbsFile), "Cannot be null");
            }

            string command;
            if (string.IsNullOrEmpty(arguments))
            {
                command = $"\"{vbsFile}\"";
            }
            else
            {
                command = $"\"{vbsFile}\"" + " " + arguments;
            }

            string scriptType;
            if (vbscriptType == VBScript.CScript)
            {
                scriptType = Extensions.EnumExtensions.GetEnumDescription(VBScript.CScript);
            }
            else
            {
                scriptType = Extensions.EnumExtensions.GetEnumDescription(VBScript.WScript);
            }

            return ProcessUtilities.StartProcess(scriptType, command, runAsAdmin, createNoWindow, false); ;
        }

        /// <summary>
        /// The run powershell.
        /// </summary>
        /// <param name="powershellFile">The powershell file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="runAsAdmin">The run as admin.</param>
        /// <param name="createNoWindow">The create no window.</param>
        /// <param name="prefix">The run as admin.</param>
        public static bool RunPowershell(string powershellFile, string arguments = "", bool runAsAdmin = false, bool createNoWindow = false, string prefix = "-NoProfile -ExecutionPolicy ByPass -File")
        {
            if (powershellFile == null)
            {
                throw new ArgumentNullException(nameof(powershellFile), "Cannot be null");
            }

            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix), "Cannot be null");
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

            string workingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SysWOW64\\WindowsPowerShell\\v1.0");

            return ProcessUtilities.StartProcess("powershell.exe", command, workingDirectory, runAsAdmin, createNoWindow, true);
        }

        /// <summary>
        /// The run batch.
        /// </summary>
        /// <param name="batchFile">The batch file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="runAsAdmin">The run as admin.</param>
        /// <param name="createNoWindow">The create no window.</param>
        public static bool RunBatch(string batchFile, string arguments = "", bool runAsAdmin = false, bool createNoWindow = false)
        {
            if (batchFile == null)
            {
                throw new ArgumentNullException(nameof(batchFile), "Cannot be null");
            }

            return ProcessUtilities.StartProcess(batchFile, arguments, runAsAdmin, createNoWindow, true);
        }
    }
}
