using ShellRun.Modules;

namespace ShellRun.Containers
{
    /// <summary>
    /// https://www.tenforums.com/tutorials/77458-rundll32-commands-list-windows-10-a.html https://winaero.com/windows-10-rundll32-command-list/
    /// </summary>
#pragma warning disable 1591

    public static class RunDLL32s
    {
        public static RunDLL32 AddRemovePrograms = new RunDLL32("Add Remove Programs", "shell32.dll", "Control_RunDLL", "appwiz.cpl,,0");
        public static RunDLL32 ContentAdvisor = new RunDLL32("Content Advisor", "msrating.dll", "RatingSetupUI");
        public static RunDLL32 ControlPanel = new RunDLL32("Control Panel", "shell32.dll", "Control_RunDLL");
        public static RunDLL32 DeleteTemporaryInternetFiles = new RunDLL32("Delete Temporary Internet Files", "InetCpl.cpl", "ClearMyTracksByProcess", "8");
        public static RunDLL32 DeleteCookies = new RunDLL32("Delete Cookies", "InetCpl.cpl", "ClearMyTracksByProcess", "2");
        public static RunDLL32 DeleteHistory = new RunDLL32("Delete History", "InetCpl.cpl", "ClearMyTracksByProcess", "1");
        public static RunDLL32 DeleteFormData = new RunDLL32("Delete Form Data", "InetCpl.cpl", "ClearMyTracksByProcess", "16");
        public static RunDLL32 DeletePasswords = new RunDLL32("Delete Passwords", "InetCpl.cpl", "ClearMyTracksByProcess", "32");
        public static RunDLL32 DeleteAll = new RunDLL32("Delete All", "InetCpl.cpl", "ClearMyTracksByProcess", "255");
        public static RunDLL32 DeleteAllFilesAndSettingsStoredByAddons = new RunDLL32("Delete All + files and settings stored by Add-ons", "InetCpl.cpl", "ClearMyTracksByProcess", "4351");
        public static RunDLL32 DateAndTimeProperties = new RunDLL32("Date and Time Properties", "shell32.dll", "Control_RunDLL", "timedate.cpl");
        public static RunDLL32 DisplaySettings = new RunDLL32("Display Settings", "shell32.dll", "Control_RunDLL", "access.cpl,,3");
        public static RunDLL32 DeviceManager = new RunDLL32("Device Manager", "devmgr.dll", "DeviceManager_Execute");
        public static RunDLL32 FolderOptionsGeneral = new RunDLL32("Folder Options – General", "shell32.dll", "Options_RunDLL", "0");
        public static RunDLL32 FolderOptionsFileTypes = new RunDLL32("Folder Options – File Types", "shell32.dll", "Control_Options", "2");
        public static RunDLL32 FolderOptionsSearch = new RunDLL32("Folder Options – Search", "shell32.dll", "Options_RunDLL", "2");
        public static RunDLL32 FolderOptionsView = new RunDLL32("Folder Options – View", "shell32.dll", "Options_RunDLL", "7");
        public static RunDLL32 ForgottenPasswordWizard = new RunDLL32("Forgotten Password Wizard", "keymgr.dll", "PRShowSaveWizardExW");
        public static RunDLL32 Hibernate = new RunDLL32("Hibernate", "powrprof.dll", "SetSuspendState");
        public static RunDLL32 InternetPropertiesDialogBox = new RunDLL32("Internet Properties dialog box", "shell32.dll", "Control_RunDLL", "Inetcpl.cpl,,4");
        public static RunDLL32 KeyboardProperties = new RunDLL32("Keyboard Properties", "shell32.dll", "Control_RunDLL", "main.cpl @1");
        public static RunDLL32 LockScreen = new RunDLL32("Lock Screen", "user32.dll", "LockWorkStation");
        public static RunDLL32 MouseButtonSwapLeftButtonToFunctionAsRight = new RunDLL32("Mouse Button – Swap left button to function as right", "user32.dll", "SwapMouseButton");
        public static RunDLL32 MousePropertiesDialogBox = new RunDLL32("Mouse Properties Dialog Box", "shell32.dll", "Control_RunDLL", "main.cpl @0,0");
        public static RunDLL32 MapNetworkDriveWizard = new RunDLL32("Map Network Drive Wizard", "shell32.dll", "SHHelpShortcuts_RunDLL", "Connect");
        public static RunDLL32 NetworkConnections = new RunDLL32("Network Connections", "shell32.dll", "Control_RunDLL", "ncpa.cpl");
        public static RunDLL32 OrganizeIEFavourites = new RunDLL32("Organize IE Favourites", "shdocvw.dll", "DoOrganizeFavDlg");
        // public static RunDLL32 OpenWithDialogBox = new RunDLL32("Open With Dialog Box", "shell32.dll", "OpenAs_RunDLL", "Any_File-name.ext");
        public static RunDLL32 PrinterUserInterface = new RunDLL32("Printer User Interface", "printui.dll", "PrintUIEntry", "/?");
        public static RunDLL32 PrinterManagementFolder = new RunDLL32("Printer Management Folder", "shell32.dll", "SHHelpShortcuts_RunDLL", "PrintersFolder");
        public static RunDLL32 PowerOptions = new RunDLL32("Power Options", "shell32.dll", "Control_RunDLL", "powercfg.cpl");
        public static RunDLL32 ProcessIdleTasks = new RunDLL32("Process Idle Tasks", "advapi32.dll", "ProcessIdleTasks");
        public static RunDLL32 RegionalAndLanguageOptions = new RunDLL32("Regional and Language Options", "shell32.dll", "Control_RunDLL", "Intl.cpl,,0");
        public static RunDLL32 StoredUsernamesAndPasswords = new RunDLL32("Stored Usernames and Passwords", "keymgr.dll", "KRShowKeyMgr");
        public static RunDLL32 SafelyRemoveHardwareDialogBox = new RunDLL32("Safely Remove Hardware Dialog Box", "shell32.dll", "Control_RunDLL", "HotPlug.dll");
        public static RunDLL32 SoundPropertiesDialogBox = new RunDLL32("Sound Properties Dialog Box", "shell32.dll", "Control_RunDLL", "Mmsys.cpl,,0");
        public static RunDLL32 SystemPropertiesBox = new RunDLL32("System Properties Box", "shell32.dll", "Control_RunDLL", "Sysdm.cpl,,3");
        public static RunDLL32 SystemPropertiesAdvanced = new RunDLL32("System Properties – Advanced", "shell32.dll", "Control_RunDLL", "sysdm.cpl,,4");
        public static RunDLL32 SystemPropertiesAutomaticUpdates = new RunDLL32("System Properties: Automatic Updates", "shell32.dll", "Control_RunDLL", "sysdm.cpl,,5");
        public static RunDLL32 TaskbarProperties = new RunDLL32("Taskbar Properties", "shell32.dll", "Options_RunDLL", "1");
        public static RunDLL32 UserAccounts = new RunDLL32("User Accounts", "shell32.dll", "Control_RunDLL", "nusrmgr.cpl");
        public static RunDLL32 UnplugEjectHardware = new RunDLL32("Unplug/Eject Hardware", "shell32.dll", "Control_RunDLL", "hotplug.dll");
        public static RunDLL32 WindowsSecurityCenter = new RunDLL32("Windows Security Center", "shell32.dll", "Control_RunDLL", "wscui.cpl");
        public static RunDLL32 WindowsAbout = new RunDLL32("Windows – About", "shell32.dll", "ShellAboutW");
        public static RunDLL32 WindowsFontsInstallationFolder = new RunDLL32("Windows Fonts Installation Folder", "shell32.dll", "SHHelpShortcuts_RunDLL", "FontsFolder");
        public static RunDLL32 WindowsFirewall = new RunDLL32("Windows Firewall", "shell32.dll", "Control_RunDLL", "firewall.cpl");
        public static RunDLL32 WirelessNetworkSetup = new RunDLL32("Wireless Network Setup", "shell32.dll", "Control_RunDLL", "NetSetup.cpl,@0,WNSW");

    }
}