using ShellRun.Modules;
using ShellRun.Properties;
using System;
using System.IO;

namespace ShellRun.Containers
{
    /// <summary>
    /// The <see cref="RunDLL32s"/> class.
    /// </summary>
#pragma warning disable 1591

    public static class RunDLL32s
    {
        public static RunDLL32 AboutWindows = new RunDLL32("About Windows", "shell32.dll", "ShellAbout");
        public static RunDLL32 AddNetworkLocationWizard = new RunDLL32("Add Network Location Wizard", "%SystemRoot%\\system32\\shwebsvc.dll", "AddNetPlaceRunDll");
        public static RunDLL32 AddPrinterWizard = new RunDLL32("Add Printer Wizard", "shell32.dll", "SHHelpShortcuts_RunDLL", "AddPrinter");
        public static RunDLL32 AddRemovePrograms = new RunDLL32("Add Remove Programs", "shell32.dll", "Control_RunDLL", "appwiz.cpl,,0");
        public static RunDLL32 AddStandardTCPIPPrinterPortWizard = new RunDLL32("Add Standard TCP/IP Printer Port Wizard", "shell32.dll", "tcpmonui.dll", "LocalAddPortUI");
        public static RunDLL32 ConfigureDefaultPrograms = new RunDLL32("Configure Default Programs", "shell32.dll", "Control_RunDLL", "appwiz.cpl,,3");
        public static RunDLL32 ContentAdvisor = new RunDLL32("Content Advisor", "msrating.dll", "RatingSetupUI");
        public static RunDLL32 ControlPanel = new RunDLL32("Control Panel", "shell32.dll", "Control_RunDLL");
        public static RunDLL32 DateAndTimeAdditionalClocksTab = new RunDLL32("Date and Time - Additional Clocks tab", "shell32.dll", "Control_RunDLL", "timedate.cpl,,1");
        public static RunDLL32 DateAndTimeProperties = new RunDLL32("Date and Time Properties", "shell32.dll", "Control_RunDLL", "timedate.cpl");
        public static RunDLL32 DeleteAll = new RunDLL32("Delete All", "InetCpl.cpl", "ClearMyTracksByProcess", "255");
        public static RunDLL32 DeleteAllFilesAndSettingsStoredByAddons = new RunDLL32("Delete All + files and settings stored by Add-ons", "InetCpl.cpl", "ClearMyTracksByProcess", "4351");
        public static RunDLL32 DeleteCookies = new RunDLL32("Delete Cookies", "InetCpl.cpl", "ClearMyTracksByProcess", "2");
        public static RunDLL32 DeleteFormData = new RunDLL32("Delete Form Data", "InetCpl.cpl", "ClearMyTracksByProcess", "16");
        public static RunDLL32 DeleteHistory = new RunDLL32("Delete History", "InetCpl.cpl", "ClearMyTracksByProcess", "1");
        public static RunDLL32 DeletePasswords = new RunDLL32("Delete Passwords", "InetCpl.cpl", "ClearMyTracksByProcess", "32");
        public static RunDLL32 DeleteTemporaryInternetFiles = new RunDLL32("Delete Temporary Internet Files", "InetCpl.cpl", "ClearMyTracksByProcess", "8");
        public static RunDLL32 DesktopIconSettings = new RunDLL32("Desktop Icon Settings", "shell32.dll", "Control_RunDLL", "desk.cpl,,0");
        public static RunDLL32 DeviceInstallationSettings = new RunDLL32("Device Installation Settings", "%SystemRoot%\\System32\\newdev.dll", "DeviceInternetSettingUi");
        public static RunDLL32 DeviceManager = new RunDLL32("Device Manager", "devmgr.dll", "DeviceManager_Execute");
        public static RunDLL32 DisplaySettings = new RunDLL32("Display Settings", "shell32.dll", "Control_RunDLL", "desk.cpl");
        public static RunDLL32 EaseOfAccessCenter = new RunDLL32("Ease of Access Center", "shell32.dll", "Control_RunDLL", "access.cpl");
        public static RunDLL32 EnvironmentVariables = new RunDLL32("Environment Variables", "sysdm.cpl", "EditEnvironmentVariables");
        public static RunDLL32 FileExplorerOptionsGeneralTab = new RunDLL32("File Explorer Options - General tab", "shell32.dll", "Options_RunDLL", "0");
        public static RunDLL32 FileExplorerOptionsSearchTab = new RunDLL32("File Explorer Options - Search tab", "shell32.dll", "Options_RunDLL", "2");
        public static RunDLL32 FileExplorerOptionsViewTab = new RunDLL32("File Explorer Options - View tab", "shell32.dll", "Options_RunDLL", "7");
        public static RunDLL32 FolderOptionsFileTypes = new RunDLL32("Folder Options – File Types", "shell32.dll", "Control_Options", "2");
        public static RunDLL32 FontsFolder = new RunDLL32("Fonts folder", "shell32.dll", "SHHelpShortcuts_RunDLL", "FontsFolder");
        public static RunDLL32 ForgottenPasswordWizard = new RunDLL32("Forgotten Password Wizard", "keymgr.dll", "PRShowSaveWizardExW");
        public static RunDLL32 GameControllers = new RunDLL32("Game Controllers", "shell32.dll", "Control_RunDLL", "joy.cpl");
        public static RunDLL32 Hibernate = new RunDLL32("Hibernate", "powrprof.dll", "SetSuspendState");
        public static RunDLL32 HibernateOrSleep = new RunDLL32("Hibernate or Sleep", "powrprof.dll", "SetSuspendState");
        public static RunDLL32 IndexingOptions = new RunDLL32("Indexing Options", "shell32.dll", "Control_RunDLL", "srchadmin.dll");
        public static RunDLL32 Infared = new RunDLL32("Infared", "shell32.dll", "Control_RunDLL", "irprops.cpl");
        public static RunDLL32 InternetExplorerDeleteAllBrowsingHistory = new RunDLL32("Internet Explorer - delete all browsing history", "InetCpl.cpl", "ClearMyTracksByProcess", "255");
        public static RunDLL32 InternetExplorerDeleteAllBrowsingHistoryAndAddonsHistory = new RunDLL32("Internet Explorer - delete all browsing history and add-ons history", "InetCpl.cpl", "ClearMyTracksByProcess", "4351");
        public static RunDLL32 InternetExplorerDeleteCookiesAndWebsiteData = new RunDLL32("Internet Explorer - delete cookies and website data", "InetCpl.cpl", "ClearMyTracksByProcess", "2");
        public static RunDLL32 InternetExplorerDeleteDownloadHistory = new RunDLL32("Internet Explorer - delete download history", "InetCpl.cpl", "ClearMyTracksByProcess", "16384");
        public static RunDLL32 InternetExplorerDeleteFormData = new RunDLL32("Internet Explorer - delete form data", "InetCpl.cpl", "ClearMyTracksByProcess", "16");
        public static RunDLL32 InternetExplorerDeleteHistory = new RunDLL32("Internet Explorer - delete history", "InetCpl.cpl", "ClearMyTracksByProcess", "1");
        public static RunDLL32 InternetExplorerDeletePasswords = new RunDLL32("Internet Explorer - delete passwords", "InetCpl.cpl", "ClearMyTracksByProcess", "32");
        public static RunDLL32 InternetExplorerDeleteTemporaryInternetFilesAndWebsiteFiles = new RunDLL32("Internet Explorer - delete temporary Internet files and website files", "InetCpl.cpl", "ClearMyTracksByProcess", "8");
        public static RunDLL32 InternetExplorerOrganizeFavorites = new RunDLL32("Internet Explorer - Organize Favorites", "shdocvw.dll", "DoOrganizeFavDlg");
        public static RunDLL32 InternetPropertiesAdvancedTab = new RunDLL32("Internet Properties - Advanced tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl,,6");
        public static RunDLL32 InternetPropertiesConnectionsTab = new RunDLL32("Internet Properties - Connections tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl,,4");
        public static RunDLL32 InternetPropertiesContentTab = new RunDLL32("Internet Properties - Content tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl,,3");
        public static RunDLL32 InternetPropertiesGeneralTab = new RunDLL32("Internet Properties - General tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl");
        public static RunDLL32 InternetPropertiesPrivacyTab = new RunDLL32("Internet Properties - Privacy tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl,,2");
        public static RunDLL32 InternetPropertiesProgramsTab = new RunDLL32("Internet Properties - Programs tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl,,5");
        public static RunDLL32 InternetPropertiesSecurityTab = new RunDLL32("Internet Properties - Security tab", "shell32.dll", "Control_RunDLL", "inetcpl.cpl,,1");
        public static RunDLL32 KeyboardProperties = new RunDLL32("Keyboard Properties", "shell32.dll", "Control_RunDLL", "main.cpl @1");
        public static RunDLL32 LockScreen = new RunDLL32("Lock Screen", "user32.dll", "LockWorkStation");
        public static RunDLL32 MapNetworkDriveWizard = new RunDLL32("Map Network Drive Wizard", "shell32.dll", "SHHelpShortcuts_RunDLL", "Connect");
        public static RunDLL32 MouseButtonSwapLeftAndRight = new RunDLL32("Mouse Button – Swap left and right", "user32.dll", "SwapMouseButton");
        public static RunDLL32 MousePropertiesButtonsTab = new RunDLL32("Mouse Properties - Buttons tab", "shell32.dll", "Control_RunDLL", "main.cpl");
        public static RunDLL32 MousePropertiesDialogBox = new RunDLL32("Mouse Properties Dialog Box", "shell32.dll", "Control_RunDLL", "main.cpl @0,0");
        public static RunDLL32 MousePropertiesHardwareTab = new RunDLL32("Mouse Properties - Hardware tab", "shell32.dll", "Control_RunDLL", "main.cpl,,4");
        public static RunDLL32 MousePropertiesPointerOptionsTab = new RunDLL32("Mouse Properties - Pointer Options tab", "shell32.dll", "Control_RunDLL", "main.cpl,,2");
        public static RunDLL32 MousePropertiesPointersTab = new RunDLL32("Mouse Properties - Pointers tab", "shell32.dll", "Control_RunDLL", "main.cpl,,1");
        public static RunDLL32 MousePropertiesWheelTab = new RunDLL32("Mouse Properties - Wheel tab", "shell32.dll", "Control_RunDLL", "main.cpl,,3");
        public static RunDLL32 NetworkConnections = new RunDLL32("Network Connections", "shell32.dll", "Control_RunDLL", "ncpa.cpl");
        public static RunDLL32 ODBCDataSourceAdministrator = new RunDLL32("ODBC Data Source Administrator", "shell32.dll", "Control_RunDLL", "odbccp32.cpl");
        public static RunDLL32 OfflineFilesDiskUsageTab = new RunDLL32("Offline Files - Disk Usage tab", "shell32.dll", "Control_RunDLL", "cscui.dll,,1");
        public static RunDLL32 OfflineFilesEncryptionTab = new RunDLL32("Offline Files - Encryption tab", "shell32.dll", "Control_RunDLL", "cscui.dll,,2");
        public static RunDLL32 OfflineFilesGeneralTab = new RunDLL32("Offline Files - General tab", "shell32.dll", "Control_RunDLL", "cscui.dll,,0");
        public static RunDLL32 OfflineFilesNetworkTab = new RunDLL32("Offline Files - Network tab", "shell32.dll", "Control_RunDLL", "cscui.dll,,3");
        public static RunDLL32 OrganizeIEFavourites = new RunDLL32("Organize IE Favourites", "shdocvw.dll", "DoOrganizeFavDlg");
        public static RunDLL32 PenAndTouch = new RunDLL32("Pen and Touch", "shell32.dll", "Control_RunDLL", "tabletpc.cpl");
        public static RunDLL32 PersonalizationBackgroundSettings = new RunDLL32("Personalization - Background Settings", "shell32.dll", "Control_RunDLL", "desk.cpl,,2");
        public static RunDLL32 PowerOptions = new RunDLL32("Power Options", "shell32.dll", "Control_RunDLL", "powercfg.cpl");
        public static RunDLL32 PrintersFolder = new RunDLL32("Printers folder", "shell32.dll", "SHHelpShortcuts_RunDLL", "PrintersFolder");
        public static RunDLL32 PrinterUserInterface = new RunDLL32("Printer User Interface", "printui.dll", "PrintUIEntry", "/?");
        public static RunDLL32 ProcessIdleTasks = new RunDLL32("Process Idle Tasks", "advapi32.dll", "ProcessIdleTasks");
        public static RunDLL32 ProgramsAndFeatures = new RunDLL32("Programs and Features", "shell32.dll", "Control_RunDLL", "appwiz.cpl,,0");
        public static RunDLL32 RegionAdministrativeTab = new RunDLL32("Region - Administrative tab", "shell32.dll", "Control_RunDLL", "Intl.cpl,,2");
        public static RunDLL32 RegionFormatsTab = new RunDLL32("Region - Formats tab", "shell32.dll", "Control_RunDLL", "Intl.cpl,,0");
        public static RunDLL32 RegionLocationTab = new RunDLL32("Region - Location tab", "shell32.dll", "Control_RunDLL", "Intl.cpl,,1");
        public static RunDLL32 SafelyRemoveHardwareDialogBox = new RunDLL32("Safely Remove Hardware Dialog Box", "shell32.dll", "Control_RunDLL", "HotPlug.dll");
        public static RunDLL32 ScreenSaverSettings = new RunDLL32("Screen Saver Settings", "shell32.dll", "Control_RunDLL", "desk.cpl,,1");
        public static RunDLL32 SecurityAndMaintenance = new RunDLL32("Security and Maintenance", "shell32.dll", "Control_RunDLL", "wscui.cpl");
        public static RunDLL32 SetUpANetworkWizard = new RunDLL32("Set Up a Network wizard", "shell32.dll", "Control_RunDLL", "NetSetup.cpl");
        public static RunDLL32 SleepOrHibernate = new RunDLL32("Sleep or Hibernate", "powrprof.dll", "SetSuspendState");
        public static RunDLL32 SoundCommunicationsTab = new RunDLL32("Sound - Communications tab", "shell32.dll", "Control_RunDLL", "Mmsys.cpl,,3");
        public static RunDLL32 SoundPlaybackTab = new RunDLL32("Sound - Playback tab", "shell32.dll", "Control_RunDLL", "Mmsys.cpl,,0");
        public static RunDLL32 SoundPropertiesDialogBox = new RunDLL32("Sound Properties Dialog Box", "shell32.dll", "Control_RunDLL", "Mmsys.cpl,,0");
        public static RunDLL32 SoundRecordingTab = new RunDLL32("Sound - Recording tab", "shell32.dll", "Control_RunDLL", "Mmsys.cpl,,1");
        public static RunDLL32 SoundSoundsTab = new RunDLL32("Sound - Sounds tab", "shell32.dll", "Control_RunDLL", "Mmsys.cpl,,2");
        public static RunDLL32 SpeechPropertiesTextToSpeechTab = new RunDLL32("Speech Properties - Text to Speech tab", "shell32.dll", "Control_RunDLL", "%SystemRoot%\\System32\\Speech\\SpeechUX\\sapi.cpl,,1");
        public static RunDLL32 StartSettings = new RunDLL32("Start Settings", "shell32.dll", "Options_RunDLL", "3");
        public static RunDLL32 StoredUsernamesAndPasswords = new RunDLL32("Stored Usernames and Passwords", "keymgr.dll", "KRShowKeyMgr");
        public static RunDLL32 SystemPropertiesAdvancedTab = new RunDLL32("System Properties - Advanced tab", "shell32.dll", "Control_RunDLL", "Sysdm.cpl,,3");
        public static RunDLL32 SystemPropertiesAutomaticUpdates = new RunDLL32("System Properties: Automatic Updates", "shell32.dll", "Control_RunDLL", "sysdm.cpl,,5");
        public static RunDLL32 SystemPropertiesComputerNameTab = new RunDLL32("System Properties - Computer Name tab", "shell32.dll", "Control_RunDLL", "Sysdm.cpl,,1");
        public static RunDLL32 SystemPropertiesHardwareTab = new RunDLL32("System Properties - Hardware tab", "shell32.dll", "Control_RunDLL", "Sysdm.cpl,,2");
        public static RunDLL32 SystemPropertiesRemoteTab = new RunDLL32("System Properties - Remote tab", "shell32.dll", "Control_RunDLL", "Sysdm.cpl,,5");
        public static RunDLL32 SystemPropertiesSystemProtectionTab = new RunDLL32("System Properties - System Protection tab", "shell32.dll", "Control_RunDLL", "Sysdm.cpl,,4");
        public static RunDLL32 TaskbarProperties = new RunDLL32("Taskbar Properties", "shell32.dll", "Options_RunDLL", "1");
        public static RunDLL32 TaskbarSettings = new RunDLL32("Taskbar Settings", "shell32.dll", "Options_RunDLL", "1");
        public static RunDLL32 TextServicesAndInputLanguages = new RunDLL32("Text Services and Input Languages", "shell32.dll", "Control_RunDLL", "input.dll,,{C07337D3-DB2C-4D0B-9A93-B722A6C106E2}");
        public static RunDLL32 UnplugEjectHardware = new RunDLL32("Unplug/Eject Hardware", "shell32.dll", "Control_RunDLL", "hotplug.dll");
        public static RunDLL32 UserAccounts = new RunDLL32("User Accounts", "shell32.dll", "Control_RunDLL", "nusrmgr.cpl");
        public static RunDLL32 WindowsFeatures = new RunDLL32("Windows Features", "shell32.dll", "Control_RunDLL", "appwiz.cpl,,2");
        public static RunDLL32 WindowsFirewall = new RunDLL32("Windows Firewall", "shell32.dll", "Control_RunDLL", "firewall.cpl");
        public static RunDLL32 WindowsFontsInstallationFolder = new RunDLL32("Windows Fonts Installation Folder", "shell32.dll", "SHHelpShortcuts_RunDLL", "FontsFolder");
        public static RunDLL32 WindowsSecurityCenter = new RunDLL32("Windows Security Center", "shell32.dll", "Control_RunDLL", "wscui.cpl");
        public static RunDLL32 WindowsToGoStartupOptions = new RunDLL32("Windows To Go Startup Options", "pwlauncher.dll", "ShowPortableWorkspaceLauncherConfigurationUX");
        public static RunDLL32 WirelessNetworkSetup = new RunDLL32("Wireless Network Setup", "shell32.dll", "Control_RunDLL", "NetSetup.cpl,@0,WNSW");

        /// <summary>
        /// Open with dialog box the specified file.
        /// </summary>
        /// <param name="fileName">The full file path.</param>
        /// <returns>The <see cref="bool"/> result.</returns>
        /// <exception cref="System.ArgumentNullException">fileName - Cannot be null or empty.</exception>
        /// <exception cref="System.IO.FileNotFoundException">The file cannot be found.</exception>
        public static bool OpenWithDialogBox(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), Settings.Default.Arg_CannotBeNullOrEmpty);
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(Settings.Default.Arg_FileNotFound, fileName);
            }

            try
            {
                RunDLL32 openWithDialogBox = new RunDLL32("Open With Dialog Box", "shell32.dll", "OpenAs_RunDLL", fileName);
                return openWithDialogBox.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}