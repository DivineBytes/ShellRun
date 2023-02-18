using NUnit.Framework;
using System;
using ShellRun.Modules;
using ShellRun.Containers;
using System.IO;
using System.Reflection;

namespace ShellRun.Test
{
    public class Tests
    {
        public static string AssemblyLocation
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location;
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                return Path.GetDirectoryName(AssemblyLocation);
            }
        }

        public static string ScriptsDirectory
        {
            get
            {
                return Path.Combine(new DirectoryInfo(AssemblyDirectory).Parent.Parent.Parent.FullName, "Code");
            }
        }

        [SetUp]
        public void Setup()
        {
            // Initialize the tests
        }

        [Test]
        public void RunDll32Test()
        {
            var x = RunDLL32s.AddRemovePrograms.Start();
            Assert.IsTrue(x);
        }

        [Test]
        public void ControlPanelTest()
        {
            var x = ControlPanels.WindowsTools.Command;
            Assert.AreEqual("control /name Microsoft.AdministrativeTools", x);
        }

        [Test]
        public void MSSettingsTest()
        {
            var x = MSSettings.WindowsUpdate.Command;
            Assert.AreEqual("ms-settings:windowsupdate", x);
        }

        [Test]
        public void ShellTest()
        {
            var x = Shells.Windows.Command;
            Assert.AreEqual("\"shell:Windows\"", x);
        }

        [Test]
        public void RunDialogTest()
        {
            var x = RunDialog.SetDefault("Hello, world!", 'z');
            Console.WriteLine(x);
        }

        [Test]
        public void CLSIDTest()
        {
            Assert.AreEqual("{BB06C0E4-D293-4f75-8A90-CB05B6477EEE}", CLSIDS.AboutSystem.GUID);
        }

        [Test]
        public void MMCTest()
        {
            Assert.AreEqual("WF.msc", MMC.WindowsFirewall.Command);
        }

        [Test]
        public void RunBatchTest()
        {
            const string ScriptName = "Batch.bat";
            string scriptPath = Path.Combine(ScriptsDirectory, ScriptName);

            if (string.IsNullOrEmpty(scriptPath))
            {
                throw new ArgumentNullException(nameof(scriptPath), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(Constants.ExceptionMessages.FileNotFound, scriptPath);
            }

            var x = Batch.Start(scriptPath);

            Assert.IsTrue(x);
        }

        [Test]
        public void RunPowerShellTest()
        {
            const string ScriptName = "PowerShell.ps1";
            string scriptPath = Path.Combine(ScriptsDirectory, ScriptName);

            if (string.IsNullOrEmpty(scriptPath))
            {
                throw new ArgumentNullException(nameof(scriptPath), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(Constants.ExceptionMessages.FileNotFound, scriptPath);
            }

            var x = PowerShell.Start(scriptPath);

            Assert.IsTrue(x);
        }

        [Test]
        public void RunVBScriptTest()
        {
            const string ScriptName = "VBScript.vbs";
            string scriptPath = Path.Combine(ScriptsDirectory, ScriptName);

            if (string.IsNullOrEmpty(scriptPath))
            {
                throw new ArgumentNullException(nameof(scriptPath), Constants.ExceptionMessages.CannotBeNullOrEmpty);
            }

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(Constants.ExceptionMessages.FileNotFound, scriptPath);
            }

            // const string Arguments = "//B //Nologo";

            var x = VBScript.Start(scriptPath, string.Empty, VBScript.VBScriptType.CScript);

            Assert.IsTrue(x);
        }
    }
}