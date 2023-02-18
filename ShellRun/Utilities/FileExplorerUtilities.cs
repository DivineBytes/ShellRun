using ShellRun.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace ShellRun.Utilities
{
    /// <summary>
    /// The <see cref="FileExplorerUtilities"/> class.
    /// </summary>
    public class FileExplorerUtilities
    {
        /// <summary>
        /// The file explorer.
        /// </summary>
        public const string Explorer = "explorer.exe";

        /// <summary>
        /// Opens the Windows File Explorer at the specified directory. Optional allows setting a
        /// selected file.
        /// </summary>
        /// <param name="directory">The directory path.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool Show(DirectoryInfo directory, bool selectFile = false, string fileName = "")
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory), Constants.ExceptionMessages.CannotBeNull);
            }

            return Show(directory.FullName, selectFile, fileName);
        }

        /// <summary>
        /// Opens the Windows File Explorer at the specified directory. Optional allows setting a
        /// selected file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool Show(FileInfo fileInfo, bool selectFile = false)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(nameof(fileInfo), Constants.ExceptionMessages.CannotBeNull);
            }

            return Show(fileInfo.Directory, selectFile, fileInfo.Name);
        }

        /// <summary>
        /// Opens the Windows File Explorer with the default program.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool OpenWithDefaultProgram(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            if (!File.Exists(path))
            {
                return false;
            }

            try
            {
                Process process = new Process
                {
                    StartInfo =
                    {
                        FileName = Explorer,
                        Arguments = "\"" + path + "\""
                    }
                };

                var result = process.Start();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        /// <summary>
        /// Opens the Windows File Explorer at the specified directory. Optional allows setting a
        /// selected file.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool Show(string directoryPath, bool selectFile = false, string fileName = "")
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                return false;
            }

            if (!Directory.Exists(directoryPath))
            {
                return false;
            }

            string argument = string.Empty;
            string explorer = Path.Combine(Windows.FullName, Explorer);

            try
            {
                // Selects the validated file path.
                if (selectFile)
                {
                    string filePath = Path.Combine(directoryPath, fileName);

                    // Validate the file Selection.
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        argument = "/select, \"" + filePath + "\"";
                    }
                }
                else
                {
                    argument = directoryPath;
                }

                Process.Start(explorer, argument);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        /// <summary>
        /// The Windows directory info.
        /// </summary>
        public static DirectoryInfo System
        {
            get
            {
                return new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System));
            }
        }

        /// <summary>
        /// The Windows directory info.
        /// </summary>
        public static DirectoryInfo Windows
        {
            get
            {
                return System.Parent;
            }
        }
    }
}