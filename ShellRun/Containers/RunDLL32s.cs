using ShellRun.Modules;

namespace ShellRun.Containers
{
    /// <summary>
    /// https://www.thewindowsclub.com/rundll32-shortcut-commands-windows
    /// https://www.tenforums.com/tutorials/77458-rundll32-commands-list-windows-10-a.html https://winaero.com/windows-10-rundll32-command-list/
    /// </summary>
#pragma warning disable 1591

    public static class RunDLL32s
    {
        public static RunDLL32 AddRemovePrograms = new RunDLL32("shell32.dll", "Control_RunDLL", "appwiz.cpl,,0");
    }
}