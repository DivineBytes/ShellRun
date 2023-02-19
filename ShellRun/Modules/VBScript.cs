using ShellRun.Base;
using ShellRun.Utilities;
using System;
using System.ComponentModel;
using System.IO;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="VBScript"/> class.
    /// </summary>
    /// <seealso cref="ShellRun.Base.ScriptBase"/>
    public class VBScript : ScriptBase
    {
        /// <summary>
        /// The CScript file info.
        /// </summary>
        /// <value>The c script.</value>
        public static FileInfo CScript
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string fileName = Extensions.EnumExtensions.GetDisplayName(VBScriptType.CScript);
                string fullPath = Path.Combine(path, fileName);
                return new FileInfo(fullPath);
            }
        }

        /// <summary>
        /// The WScript file info.
        /// </summary>
        /// <value>The w script.</value>
        public static FileInfo WScript
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string fileName = Extensions.EnumExtensions.GetDisplayName(VBScriptType.WScript);
                string fullPath = Path.Combine(path, fileName);
                return new FileInfo(fullPath);
            }
        }

        /// <summary>
        /// The <see cref="VBScriptType"/> enum.
        /// </summary>
        public enum VBScriptType
        {
            /// <summary>
            /// POP-UPS Disabled.
            /// </summary>
            [Attributes.DisplayName("cscript.exe")]
            [Description("Console Based Script Host")]
            CScript = 0,

            /// <summary>
            /// POP-UPS Enabled.
            /// </summary>
            [Attributes.DisplayName("wscript.exe")]
            [Description("Windows Based Script Host")]
            WScript = 1
        }

        /// <summary>
        /// Start the VBScript file.
        /// </summary>
        /// <param name="vbsFile">The vbs file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="vbscriptType">The vbscript type.</param>
        /// <param name="runAsAdmin">The run as admin.</param>
        /// <param name="createNoWindow">The create no window.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        /// <exception cref="System.ArgumentNullException">vbsFile - Cannot be null or empty.</exception>
        public static bool Start(string vbsFile, string arguments = "", VBScriptType vbscriptType = VBScriptType.CScript, bool runAsAdmin = false, bool createNoWindow = false)
        {
            if (string.IsNullOrEmpty(vbsFile))
            {
                throw new ArgumentNullException(nameof(vbsFile), Constants.ExceptionMessages.CannotBeNullOrEmpty);
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
            if (vbscriptType == VBScriptType.CScript)
            {
                scriptType = Extensions.EnumExtensions.GetDisplayName(VBScriptType.CScript);
            }
            else
            {
                scriptType = Extensions.EnumExtensions.GetDisplayName(VBScriptType.WScript);
            }

            return ProcessUtilities.StartProcess(scriptType, command, runAsAdmin, createNoWindow, false); ;
        }
    }
}