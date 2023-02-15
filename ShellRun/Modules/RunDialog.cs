using Microsoft.Win32;
using ShellRun.Containers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="RunDialog"/>.
    /// </summary>
    public class RunDialog
    {
        const string MRUList = "MRUList";

        /// <summary>
        /// The <see cref="RunFileDialogFlags"/>.
        /// </summary>
        [Flags]
        public enum RunFileDialogFlags : uint
        {
            /// <summary>
            /// Don't use any of the flags (only works alone)
            /// </summary>
            [Description("Don't use any of the flags (only works alone).")]
            None = 0x0000,

            /// <summary>
            /// Removes the browse button
            /// </summary>
            [Description("Removes the browse button.")]
            NoBrowse = 0x0001,

            /// <summary>
            /// No default item selected
            /// </summary>
            [Description("No default item selected.")]
            NoDefault = 0x0002,

            /// <summary>
            /// Calculates the working directory from the file name
            /// </summary>
            [Description("Calculates the working directory from the file name.")]
            CalcDirectory = 0x0004,

            /// <summary>
            /// Removes the edit box label
            /// </summary>
            [Description("Removes the edit box label.")]
            NoLabel = 0x0008,

            /// <summary>
            /// Removes the separate memory space checkbox (Windows NT only)
            /// </summary>
            [Description("Removes the separate memory space checkbox (Windows NT only).")]
            NoSeperateMemory = 0x0020
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "#61", SetLastError = true)]
        public static extern bool SHRunFileDialog(IntPtr hwndOwner, IntPtr hIcon, string lpszPath, string lpszDialogTitle, string lpszDialogTextBody, RunFileDialogFlags uflags);

        /// <summary>
        /// Shows the custom Run Dialog.
        /// </summary>
        /// <param name="text">The dialog body text.</param>
        /// <param name="title">The dialog title.</param>
        /// <param name="workingDirectory">The working directory.</param>
        /// <param name="runFileDialogFlags">The run file dialog flags.</param>
        public static void Show(string title = "Run", string text = "Type the name of a program, folder, document, or Internet resource, and Windows will open it for you.", string workingDirectory = "", RunFileDialogFlags runFileDialogFlags = RunFileDialogFlags.CalcDirectory)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                workingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            }

            SHRunFileDialog(IntPtr.Zero, IntPtr.Zero, workingDirectory, title, text, runFileDialogFlags);
        }

        /// <summary>
        /// Opens the Run Dialog.
        /// </summary>
        public static bool Open()
        {
            try
            {
               return CLSIDS.Run.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        /// <summary>
        /// The base key.
        /// </summary>
        public static RegistryKey BaseKey
        {
            get
            {
                try
                {
                    RegistryKey baseKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RunMRU", true);

                    if (baseKey != null)
                    {
                        return baseKey;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                return null;
            }
        }

        /// <summary>
        /// The clear history.
        /// </summary>
        public static bool ClearHistory()
        {
            try
            {
                RegistryKey baseKey = BaseKey;

                if (baseKey != null)
                {
                    string[] valueKeys = baseKey.GetValueNames();

                    foreach (string valueKey in valueKeys)
                    {
                        baseKey.DeleteValue(valueKey);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        /// <summary>
        /// The set default.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="keyName">The key name.</param>
        public static bool SetDefault(string command, char keyName = 'z')
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command), "Cannot be null");
            }

            try
            {
                RegistryKey baseKey = BaseKey;

                if (baseKey != null)
                {
                    // Set the command to a value
                    baseKey.SetValue(keyName.ToString(), command, RegistryValueKind.String);

                    // Get the MRUList
                    string mruList = "";
                    object mruListObj = null;

                    try
                    {
                        mruListObj = baseKey.GetValue(MRUList);
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex);
                    }
                    finally
                    {
                        if (mruListObj == null)
                        {
                            mruList = string.Empty;
                        }
                    }
                    
                    string newMRUList = string.Empty;
                    if (mruList.Length > 0)
                    {
                        var mruListChar = mruList.ToCharArray();

                        // Validate the first character is not equal to the key name
                        var xx = mruListChar[0];
                        if (xx != keyName)
                        {
                            // Add the char to the prefix of the mruList
                            newMRUList = keyName.ToString() + mruList;
                        }
                    }
                    else
                    {
                        newMRUList = keyName.ToString();
                    }

                    // Update the MRUList
                    baseKey.SetValue(MRUList, newMRUList, RegistryValueKind.String);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        /// <summary>
        /// The get history.
        /// </summary>
        public static List<KeyValuePair<char, string>> GetHistory()
        {
            List<KeyValuePair<char, string>> runHistory = new List<KeyValuePair<char, string>>();

            try
            {
                RegistryKey baseKey = BaseKey;

                if (baseKey != null)
                {
                    string key = baseKey.GetValue(MRUList).ToString();
                    char[] charArray = key.ToCharArray();

                    foreach (char data in charArray)
                    {
                        var keyName = data.ToString();
                        string keyValue = baseKey.GetValue(keyName).ToString();

                        KeyValuePair<char, string> pair = new KeyValuePair<char, string>(data, keyValue);
                        runHistory.Add(pair);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return runHistory;
        }
    }
}
