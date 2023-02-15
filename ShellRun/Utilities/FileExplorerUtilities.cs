using System;
using System.Diagnostics;
using System.IO;

namespace ShellRun.Utilities
{
    /// <summary>
    ///     The <see cref="FileExplorer" /> class.
    /// </summary>
    public class FileExplorer
    {
        /// <summary>The file explorer.</summary>
        public const string Explorer = "explorer.exe";

        /// <summary>Opens the Windows File Explorer at the specified directory. Optional allows setting a selected file.</summary>
        /// <param name="directory">The directory path.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool Show(DirectoryInfo directory, bool selectFile = false, string fileName = "")
        {
            return Show(directory.FullName, selectFile, fileName);
        }

        /// <summary>Opens the Windows File Explorer at the specified directory. Optional allows setting a selected file.</summary>
        /// <param name="fileInfo">The file info.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool Show(FileInfo fileInfo, bool selectFile = false)
        {
            return Show(fileInfo.Directory, selectFile, fileInfo.Name);
        }

        /// <summary>Opens the Windows File Explorer with the default program.</summary>
        /// <param name="path">The file path.</param>
        /// <returns>The <see cref="bool" />.</returns>
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

        /// <summary>Opens the Windows File Explorer at the specified directory. Optional allows setting a selected file.</summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="bool" />.</returns>
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

                Process.Start(Path.Combine(Windows.FullName, Explorer), argument);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        #region Public Properties

        /// <summary>The Windows directory info.</summary>
        public static DirectoryInfo System
        {
            get
            {
                return new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System));
            }
        }

        /// <summary>The Windows directory info.</summary>
        public static DirectoryInfo Windows
        {
            get
            {
                return System.Parent;
            }
        }

        #endregion
    }
}
