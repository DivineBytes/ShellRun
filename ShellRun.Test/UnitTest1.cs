using NUnit.Framework;
using System;
using ShellRun.Modules;
using ShellRun.Attributes;
using ShellRun.Containers;
using System.IO;
using System.Reflection;

namespace ShellRun.Test
{
    public class Tests
    {
        public string AssemblyPath = string.Empty;
        public string AssemblyDirectory = string.Empty;

        [SetUp]
        public void Setup()
        {
            // Configure the necessary test data.
            AssemblyPath = Assembly.GetExecutingAssembly().Location;
            AssemblyDirectory = Path.GetDirectoryName(AssemblyPath);
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
            var x = RunDialog.SetDefault("Hello World", 'z');
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
            const string Content = "@ECHO OFF\nTITLE Batch Test\nECHO Hello World.\nECHO.\nPAUSE";
            const string FileName = "BatchTest.bat";

            string FilePath = Path.Combine(AssemblyDirectory, FileName);

            File.WriteAllText(FilePath, Content);
            var x = Scripts.RunBatch(FilePath);

            Assert.IsTrue(x);
        }

        [Test]
        public void RunPowershellTest()
        {
            const string Content = "Write-Host 'Hello, World!'\n$host.UI.RawUI.ReadKey(\"NoEcho,IncludeKeyDown\")";
            const string FileName = "PowerShellTest.ps1";

            string FilePath = Path.Combine(AssemblyDirectory, FileName);

            File.WriteAllText(FilePath, Content);
            var x = Scripts.RunPowershell(FilePath);

            Assert.IsTrue(x);
        }

        [Test]
        public void RunVBScriptTest()
        {
            const string Content = "function Main()\n'Display message on computer screen.\nresult = MsgBox(\"Hello, World!\", vbOKOnly, \"Title\")\nend function\n\ncall Main";
            const string FileName = "VBScriptTest.vbs";
            const string Arguments = "//B //Nologo";

            string FilePath = Path.Combine(AssemblyDirectory, FileName);
            Console.WriteLine(FilePath);
            File.WriteAllText(FilePath, Content);
            var x = Scripts.RunVBScript(FilePath, "", Scripts.VBScript.CScript);

            Assert.IsTrue(x);
        }
    }
}