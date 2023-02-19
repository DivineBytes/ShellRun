using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace ShellRun.Modules
{
    /// <summary>
    /// The <see cref="NETFramework"/> class.
    /// </summary>
    public class NETFramework
    {
        /// <summary>
        /// Gets the default referenced assemblies.
        /// </summary>
        /// <returns>The <see cref="string"/> result.</returns>
        public static string[] DefaultReferencedAssemblies
        {
            get
            {
                string[] defaultReferencedAssemblies = new string[]
                {
                    "mscorlib.dll",
                    "System.dll",
                    "System.Core.dll",
                    "System.Data.dll",
                    "System.Drawing.dll",
                    "System.Windows.Forms.dll",
                    "System.Xml.dll"
                };

                return defaultReferencedAssemblies;
            }
        }

        /// <summary>
        /// Starts the code files using a customizable <see cref="CompileConstructor"/>.
        /// </summary>
        /// <param name="sourceCodeFiles">The source code files.</param>
        /// <param name="compileConstructor">The customizable compile constructor.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        /// <exception cref="ArgumentNullException">The argument cannot be null or empty.</exception>
        public static bool Start(string[] sourceCodeFiles, CompileConstructor compileConstructor)
        {
            if (sourceCodeFiles == null || sourceCodeFiles.Length == 0)
            {
                throw new ArgumentNullException(nameof(sourceCodeFiles), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (compileConstructor == null)
            {
                throw new ArgumentNullException(nameof(compileConstructor), Constants.ExceptionMessages.CannotBeNull);
            }

            string[] sources = new string[sourceCodeFiles.Length];

            try
            {
                // Read all the code files to sources
                for (int i = 0; i < sourceCodeFiles.Length; i++)
                {
                    string codeFile = sourceCodeFiles[i];
                    sources[i] = File.ReadAllText(codeFile);
                }

                // Compile the assembly from source
                CompilerResults compilerResults = compileConstructor.CodeDomProvider.CompileAssemblyFromSource(compileConstructor.CompilerParameters, sources);

                // Check for compilation errors
                if (compilerResults.Errors.HasErrors)
                {
                    Console.WriteLine($"Compile Errors [{compilerResults.Errors.Count}]:");
                    StringBuilder sb = new StringBuilder();

                    foreach (CompilerError error in compilerResults.Errors)
                    {
                        string compileErrorText = string.Format("Error ({0}): [Ln: {1}, Col: {2}] --> {3}", error.ErrorNumber, error.Line, error.Column, error.ErrorText);
                        sb.AppendLine(compileErrorText);
                    }

                    Console.WriteLine(sb.ToString());
                }
                else
                {
                    // Get the compiled assembly
                    Assembly assembly = compilerResults.CompiledAssembly;

                    // Get the assembly code entry point
                    Type program = assembly.GetType(compileConstructor.CodeEntryPoint.EntryPoint);

                    object instance = null;
                    try
                    {
                        // Create an instance of the program
                        instance = Activator.CreateInstance(program);

                        try
                        {
                            // Get the program entry method
                            MethodInfo main = program.GetMethod(compileConstructor.CodeEntryPoint.MethodName);

                            try
                            {
                                // Invoke the method
                                main.Invoke(instance, compileConstructor.CodeEntryPoint.Parameters);
                                return true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"Error: Failed to invoke the instance.");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error: The entry point (method name) for the instance is invalid.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error: The entry point (namespace name and/or class name) for the instance is invalid.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}\n");
            }

            return false;
        }

        /// <summary>
        /// The <see cref="CodeEntryPoint"/> class.
        /// </summary>
        public class CodeEntryPoint
        {
            /// <summary>
            /// The default class name.
            /// </summary>
            public const string ClassNameDefault = "Program";

            /// <summary>
            /// The default method name.
            /// </summary>
            public const string MethodNameDefault = "Main";

            /// <summary>
            /// Initializes the <see cref="CodeEntryPoint"/>.
            /// </summary>
            private CodeEntryPoint()
            {
                ClassName = ClassNameDefault;
                MethodName = MethodNameDefault;
                Namespace = string.Empty;
                Parameters = null;
            }

            /// <summary>
            /// Initializes the <see cref="CodeEntryPoint"/> class.
            /// </summary>
            /// <param name="namespaceName">The namespace name.</param>
            /// <param name="className">The class name.</param>
            /// <param name="methodName">The method name.</param>
            /// <param name="parameters">The method invoke parameters.</param>
            /// <exception cref="System.ArgumentNullException">
            /// namespaceName - Cannot be null or empty. or className - Cannot be null or empty. or
            /// methodName - Cannot be null or empty.
            /// </exception>
            /// <exception cref="ArgumentNullException">The argument cannot be null or empty.</exception>
            public CodeEntryPoint(string namespaceName, string className = ClassNameDefault, string methodName = MethodNameDefault, object[] parameters = null) : this()
            {
                if (string.IsNullOrEmpty(namespaceName))
                {
                    throw new ArgumentNullException(nameof(namespaceName), Constants.ExceptionMessages.CannotBeNullOrEmpty);
                }

                if (string.IsNullOrEmpty(className))
                {
                    throw new ArgumentNullException(nameof(className), Constants.ExceptionMessages.CannotBeNullOrEmpty);
                }

                if (string.IsNullOrEmpty(methodName))
                {
                    throw new ArgumentNullException(nameof(methodName), Constants.ExceptionMessages.CannotBeNullOrEmpty);
                }

                Namespace = namespaceName;
                ClassName = className;
                MethodName = methodName;
                Parameters = parameters;
            }

            /// <summary>
            /// The entry point.
            /// </summary>
            /// <value>The entry point.</value>
            public string EntryPoint
            {
                get
                {
                    return Namespace + "." + ClassName;
                }
            }

            /// <summary>
            /// The namespace.
            /// </summary>
            /// <value>The namespace.</value>
            public string Namespace { get; private set; }

            /// <summary>
            /// The class name.
            /// </summary>
            /// <value>The name of the class.</value>
            public string ClassName { get; private set; }

            /// <summary>
            /// The method name.
            /// </summary>
            /// <value>The name of the method.</value>
            public string MethodName { get; private set; }

            /// <summary>
            /// The parameters.
            /// </summary>
            /// <value>The parameters.</value>
            public object[] Parameters { get; private set; }
        }

        /// <summary>
        /// The <see cref="CompileConstructor"/> class.
        /// </summary>
        public class CompileConstructor
        {
            /// <summary>
            /// The <see cref="CodeProvider"/> enum.
            /// </summary>
            public enum CodeProvider
            {
                /// <summary>
                /// The CSharp language.
                /// </summary>
                [Attributes.DisplayName("csharp")]
                [Description("CSharp (C#)")]
                CSharp = 0,

                /// <summary>
                /// The Visual Basic language.
                /// </summary>
                [Attributes.DisplayName("visualbasic")]
                [Description("Visual Basic (VB)")]
                VisualBasic = 1
            }

            /// <summary>
            /// The <see cref="TargetFramework"/> enum.
            /// </summary>
            public enum TargetFramework
            {
                /// <summary>
                /// The .NET Framework v2.0.
                /// </summary>
                [Description(".NET Framework v2.0")]
                [Attributes.DisplayName("v2.0")]
                v2 = 0,

                /// <summary>
                /// The .NET Framework v4.0.
                /// </summary>
                [Description(".NET Framework v4.0")]
                [Attributes.DisplayName("v4.0")]
                v4 = 1
            }

            /// <summary>
            /// Initializes the <see cref="CompileConstructor"/>.
            /// </summary>
            private CompileConstructor()
            {
                CodeDomProvider = null;
                CodeEntryPoint = null;
                Provider = CodeProvider.CSharp;
                ReferencedAssemblies = new string[0];
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CompileConstructor"/> class.
            /// </summary>
            /// <param name="codeEntryPoint">The code entry point.</param>
            /// <param name="provider">The provider.</param>
            /// <param name="targetFramework">The target framework.</param>
            /// <param name="referencedAssemblies">The referenced assemblies.</param>
            /// <exception cref="System.ArgumentNullException">codeEntryPoint - Cannot be null.</exception>
            public CompileConstructor(CodeEntryPoint codeEntryPoint, CodeProvider provider = CodeProvider.CSharp, TargetFramework targetFramework = TargetFramework.v4, string[] referencedAssemblies = null) : this()
            {
                if (codeEntryPoint == null)
                {
                    throw new ArgumentNullException(nameof(codeEntryPoint), Constants.ExceptionMessages.CannotBeNull);
                }

                CodeEntryPoint = codeEntryPoint;
                Provider = provider;

                // Get the target framework version
                TargetFrameworkVersion = targetFramework;
                string targetFrameworkVersion = string.Empty;
                switch (targetFramework)
                {
                    case TargetFramework.v2:
                        targetFrameworkVersion = Extensions.EnumExtensions.GetDisplayName(TargetFramework.v2);
                        break;

                    case TargetFramework.v4:
                        targetFrameworkVersion = Extensions.EnumExtensions.GetDisplayName(TargetFramework.v4);
                        break;
                }

                // Assign the target framework version
                Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", targetFrameworkVersion}
                };

                // Determine the code provider
                switch (Provider)
                {
                    case CodeProvider.CSharp:
                        CodeDomProvider = new CSharpCodeProvider(providerOptions);
                        break;

                    case CodeProvider.VisualBasic:
                        CodeDomProvider = new VBCodeProvider(providerOptions);
                        break;
                }

                // Validate the referenced assemblies
                if (referencedAssemblies == null || referencedAssemblies.Length == 0)
                {
                    // Load the default referenced assemblies
                    referencedAssemblies = DefaultReferencedAssemblies;
                }

                ReferencedAssemblies = referencedAssemblies;

                // Define compile parameters
                CompilerParameters = new CompilerParameters();

                // Add referenced assemblies
                foreach (string referencedAssembly in ReferencedAssemblies)
                {
                    if (!string.IsNullOrEmpty(referencedAssembly))
                    {
                        CompilerParameters.ReferencedAssemblies.Add(referencedAssembly);
                    }
                }

                // True = memory generation OR false = external file generation
                CompilerParameters.GenerateInMemory = true;

                // True = exe file generation OR false = dll file generation
                CompilerParameters.GenerateExecutable = true;
            }

            /// <summary>
            /// The code entry point.
            /// </summary>
            /// <value>The code entry point.</value>
            public CodeEntryPoint CodeEntryPoint { get; private set; }

            /// <summary>
            /// The CodeDomProvider.
            /// </summary>
            /// <value>The code DOM provider.</value>
            public CodeDomProvider CodeDomProvider { get; private set; }

            /// <summary>
            /// Gets the compiler parameters.
            /// </summary>
            /// <value>The compiler parameters.</value>
            public CompilerParameters CompilerParameters { get; private set; }

            /// <summary>
            /// Gets the provider.
            /// </summary>
            /// <value>The provider.</value>
            public CodeProvider Provider { get; private set; }

            /// <summary>
            /// Gets the referenced assemblies.
            /// </summary>
            /// <value>The referenced assemblies.</value>
            public string[] ReferencedAssemblies { get; private set; }

            /// <summary>
            /// Gets the target framework version.
            /// </summary>
            /// <value>The target framework version.</value>
            public TargetFramework TargetFrameworkVersion { get; private set; }
        }
    }
}