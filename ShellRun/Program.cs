using ShellRun.Modules;
using ShellRun.Properties;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ShellRun
{
    /// <summary>
    /// The <see cref="Program" /> class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="System.ArgumentException">Invalid code provider. - codeProvider</exception>
        public static void Main(string[] args)
        {
            // Initialize
            Console.Title = Application.ProductName;
            ShowDescription();

            // Validate the arguments
            if (args.Length > 0)
            {
                string initialArgument = args[0].ToLower();
                switch (initialArgument)
                {
                    case "code":
                        Console.WriteLine("Usage:");
                        Console.WriteLine("\"csharp\" \"Namespace;ClassName;MethodName\" \"System.dll;System.Windows.dll\" \"Folder\\Program.cs;Folder\\Utilities.cs\"");
                        // Console.WriteLine("\"visualbasic\" \"AppName;Program;Main\" \"System.dll;System.Windows.dll\" \"Folder\\Program.vb;Folder\\Utilities.vb\"\n");

                        Console.WriteLine();

                        // Arguments:
                        // arg0: command
                        // arg1: code language -> csharp || visualbasic
                        // arg2: entry point code -> "namespaceName;className;methodName"
                        // arg3: referenced assemblies -> ex: "System.dll;System.Windows.Forms.dll"
                        // arg4: code file/s -> ex: "program.cs;utilities.cs"

                        Console.WriteLine("Starting compiler...");

                        // Determine the code provider
                        string codeProviderText = args[1].ToLower();
                        NETFramework.CompileConstructor.CodeProvider codeProvider;
                        switch (codeProviderText)
                        {
                            case "csharp":
                                codeProvider = NETFramework.CompileConstructor.CodeProvider.CSharp;
                                break;

                            case "visualbasic":
                                codeProvider = NETFramework.CompileConstructor.CodeProvider.VisualBasic;
                                break;

                            default:
                                codeProvider = NETFramework.CompileConstructor.CodeProvider.CSharp;
                                Console.WriteLine("Error: Unknown language code is being used! Using the default: " + Extensions.EnumExtensions.GetDescription(codeProvider));
                                break;
                        }

                        Console.WriteLine("Language: " + Extensions.EnumExtensions.GetDescription(codeProvider));

                        // Get the entry point methods
                        string[] entryPoints = args[2].Split(Constants.Separator);
                        string namespaceName = entryPoints[0];

                        string className = NETFramework.CodeEntryPoint.ClassNameDefault;
                        if (entryPoints.Length >= 2)
                        {
                            if(string.IsNullOrEmpty(entryPoints[1]))
                            {
                                className = NETFramework.CodeEntryPoint.ClassNameDefault;
                            }
                            else
                            {
                                className = entryPoints[1];
                            }
                        }

                        string methodName = NETFramework.CodeEntryPoint.MethodNameDefault;
                        if (entryPoints.Length == 3)
                        {
                            if (string.IsNullOrEmpty(entryPoints[2]))
                            {
                                methodName = NETFramework.CodeEntryPoint.MethodNameDefault;
                            }
                            else
                            {
                                methodName = entryPoints[2];
                            }
                        }

                        // Create the code entry point object
                        NETFramework.CodeEntryPoint codeEntryPoint = new NETFramework.CodeEntryPoint(namespaceName, className, methodName);
                        Console.WriteLine("\nCode Entry Point:");
                        Console.WriteLine("Entry Point: " + codeEntryPoint.EntryPoint);
                        Console.WriteLine("Entry Method: " + codeEntryPoint.MethodName + "\n");

                        // Get the referenced assemblies
                        string referencedAssembliesList = args[3];
                        string[] referencedAssemblies;

                        if (string.IsNullOrEmpty(referencedAssembliesList) || referencedAssembliesList == "null")
                        {
                            referencedAssemblies = NETFramework.DefaultReferencedAssemblies;
                        }
                        else
                        {
                            referencedAssemblies = referencedAssembliesList.Split(Constants.Separator);
                        }

                        Console.WriteLine("Referenced Assemblies:");
                        for (int i = 0; i < referencedAssemblies.Length; i++)
                        {
                            string referencedAssembly = referencedAssemblies[i];
                            Console.WriteLine(referencedAssembly);
                        }

                        // Create the compiler constructor
                        NETFramework.CompileConstructor compileConstructor = new NETFramework.CompileConstructor(codeEntryPoint, codeProvider, NETFramework.CompileConstructor.TargetFramework.v4, referencedAssemblies);

                        // Get the source code file/s
                        Console.WriteLine("\nSource Code File/s:");

                        string sourceCodeLocations = args[4];
                        string[] sourceCodeFiles = sourceCodeLocations.Split(Constants.Separator);

                        // Display the source code file/s
                        for (int i = 0; i < sourceCodeFiles.Length; i++)
                        {
                            string sourceCodeFile = sourceCodeFiles[i];
                            Console.WriteLine(sourceCodeFile);
                        }

                        // Output the result
                        Console.WriteLine("\nOutput:\n");

                        // Invoke the code files
                        bool compiledResult = NETFramework.Start(sourceCodeFiles, compileConstructor);

                        // Compile result
                        if(!compiledResult)
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine("Compiled: " + compiledResult);
                        break;

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