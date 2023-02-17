using ShellRun.Base;
using ShellRun.Utilities;
using System;
using System.IO;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="RunDLL" /> class.
    /// </summary>
    /// <seealso cref="ShellRun.Base.CommandBase" />
    public class RunDLL : CommandBase
    {
        /// <summary>
        /// The executable file.
        /// </summary>
        public const string Executable = "rundll32.exe";

        /// <summary>
        /// The empty RunDLL.
        /// </summary>
        public static RunDLL Empty = new RunDLL();

        /// <summary>
        /// The <see cref="RunDLL" />.
        /// </summary>
        /// <param name="dllName">The dll file.</param>
        /// <param name="entryPoint">The dll entry point.</param>
        public RunDLL(string dllName, string entryPoint) : this(dllName, entryPoint, string.Empty)
        {
        }

        /// <summary>
        /// The <see cref="RunDLL" />.
        /// </summary>
        /// <param name="dllName">The dll file.</param>
        /// <param name="entryPoint">The dll entry point.</param>
        /// <param name="arguments">The dll arguments.</param>
        /// <exception cref="System.ArgumentNullException">
        /// dllName - Cannot be null or empty.
        /// or
        /// entryPoint - Cannot be null or empty.
        /// or
        /// arguments - Cannot be null.
        /// </exception>
        public RunDLL(string dllName, string entryPoint, string arguments = "") : this()
        {
            if (string.IsNullOrEmpty(dllName))
            {
                throw new ArgumentNullException(nameof(dllName), "Cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(entryPoint))
            {
                throw new ArgumentNullException(nameof(entryPoint), "Cannot be null or empty.");
            }

            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments), "Cannot be null.");
            }

            DLLName = dllName;
            EntryPoint = entryPoint;
            Arguments = arguments;
        }

        /// <summary>
        /// The <see cref="RunDLL" />.
        /// </summary>
        private RunDLL()
        {
            DLLName = string.Empty;
            EntryPoint = string.Empty;
            Arguments = string.Empty;
        }

        /// <summary>
        /// The RunDll32 file info.
        /// </summary>
        /// <value>
        /// The run DLL32.
        /// </value>
        public static FileInfo RunDll32
        {
            get
            {
                string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), Executable);
                return new FileInfo(fullPath);
            }
        }

        /// <summary>
        /// The arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public string Arguments { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public string Command
        {
            get
            {
                string command;
                if (string.IsNullOrEmpty(Arguments))
                {
                    command = string.Format("{0} {1},{2}", RunDll32.FullName, DLLName, EntryPoint);
                }
                else
                {
                    command = string.Format("{0} {1},{2} {3}", RunDll32.FullName, DLLName, EntryPoint, Arguments);
                }

                return command;
            }
        }

        /// <summary>
        /// The DLL Name.
        /// </summary>
        /// <value>
        /// The name of the DLL.
        /// </value>
        public string DLLName { get; private set; }

        /// <summary>
        /// The entry point.
        /// </summary>
        /// <value>
        /// The entry point.
        /// </value>
        public string EntryPoint { get; private set; }

        /// <summary>
        /// Executes the DLL file.
        /// </summary>
        /// <param name="dllName">The dll file.</param>
        /// <param name="entryPoint">The dll entry point.</param>
        /// <param name="arguments">The dll arguments.</param>
        /// <returns>
        /// The <see cref="bool" /> result.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// dllName - Cannot be null or empty.
        /// or
        /// entryPoint - Cannot be null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Cannot be null or empty.</exception>
        public static bool Start(string dllName, string entryPoint, string arguments = "")
        {
            // Example -> RUNDLL32.EXE <dllname>,<entrypoint> <optional arguments>

            if (string.IsNullOrEmpty(dllName))
            {
                throw new ArgumentNullException(nameof(dllName), "Cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(entryPoint))
            {
                throw new ArgumentNullException(nameof(entryPoint), "Cannot be null or empty.");
            }

            string argument;
            if (string.IsNullOrEmpty(arguments))
            {
                argument = string.Format("{0},{1}", dllName, entryPoint);
            }
            else
            {
                argument = string.Format("{0},{1} {2}", dllName, entryPoint, arguments);
            }

            try
            {
                return ProcessUtilities.StartProcess(RunDll32.FullName, argument, false, false, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

#pragma warning disable 1591

        public override bool Start()
        {
            try
            {
                return Start(DLLName, EntryPoint, Arguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}