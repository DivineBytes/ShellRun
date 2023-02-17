using ShellRun.Modules;
using ShellRun.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ShellRun
{
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            // Initialize
            Console.Title = Application.ProductName;
            ShowDescription();

            // Validate the arguments
            if (args.Length > 0)
            {
                string initialArgument = args[0];
                switch (initialArgument)
                {
                    //case "compile":
                    //    // Arguments:
                    //    // arg0: command
                    //    // arg1: namespace

                    //    // arg2: codeProvider -> {csharp,visualbasic}
                    //    // arg3: referencedAssemblies -> {System.dll,System.Forms.dll}

                    //    // arg4: code file/s -> {program.cs,utilities.cs}

                    //    string namespaceName = args[1];

                    //    NETFramework.CodeEntryPoint codeEntryPoint = new NETFramework.CodeEntryPoint(namespaceName);
                    //    Console.WriteLine("Code Entry Point:");
                    //    Console.WriteLine("Entry Point: " + codeEntryPoint.EntryPoint);
                    //    Console.WriteLine("Entry Method: " + codeEntryPoint.MethodName + "\n");

                    //    string codeProvider = args[2];

                    //    string referencedAssemblies = args[3];

                    //    NETFramework.CompileConstructor compileConstructor = new NETFramework.CompileConstructor(codeEntryPoint, NETFramework.CompileConstructor.CodeProvider.CSharp, NETFramework.CompileConstructor.TargetFramework.v4, null);

                    //    Console.WriteLine("Source Code File/s:");

                    //    // Read the code files from the arguments
                    //    List<string> codeFiles = new List<string>();
                    //    for (int i = 4; i < args.Length; i++)
                    //    {
                    //        string arguments = args[i];

                    //        if (arguments != args[0] && arguments != args[1])
                    //        {
                    //            if (!string.IsNullOrEmpty(arguments))
                    //            {
                    //                Console.WriteLine(arguments);
                    //                codeFiles.Add(arguments);
                    //            }
                    //        }
                    //    }

                    //    Console.WriteLine("\nOutput Result:\n");

                    //    // Invoke the code files
                    //    bool compiledResult = NETFramework.Start(codeFiles, compileConstructor);

                    //    Console.WriteLine("\nCompiled: " + compiledResult);
                    //    break;

                    case "debug":
                        for (int i = 0; i < args.Length; i++)
                        {
                            string argument = args[i];
                            Console.WriteLine($"Argument ({i}): " + argument);
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown parameter/s.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No parameter/s have been passed.");
            }
        }

        /// <summary>
        /// Shows the description.
        /// </summary>
        private static void ShowDescription()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Application.ProductName} [Version {Application.ProductVersion}]");

            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            stringBuilder.AppendLine($"(c) {fileVersionInfo.CompanyName}. All rights reserved.");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Website: {Settings.Default.Website}");

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}