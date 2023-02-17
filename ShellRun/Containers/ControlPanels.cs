using ShellRun.Modules;
using System.Collections.Generic;

namespace ShellRun.Containers
{
    /// <summary>
    /// The <see cref="ControlPanels"/> class.
    /// </summary>
#pragma warning disable 1591

    public static class ControlPanels
    {
        public static ControlPanelApplet AddADeviceWizard = new ControlPanelApplet("Add a Device wizard", new List<string> { "%windir%\\System32\\DevicePairingWizard.exe" });
        public static ControlPanelApplet AddHardwareWizard = new ControlPanelApplet("Add Hardware wizard", new List<string> { "%windir%\\System32\\hdwwiz.exe" });
        public static ControlPanelApplet AddAPrinterWizard = new ControlPanelApplet("Add a Printer wizard", new List<string> { "rundll32 shell32.dll,SHHelpShortcuts_RunDLL AddPrinter" });
        public static ControlPanelApplet AdditionalClocks = new ControlPanelApplet("Additional Clocks", new List<string> { "rundll32 shell32.dll,Control_RunDLL timedate.cpl,,1" });
        public static ControlPanelApplet AutoPlay = new ControlPanelApplet("AutoPlay", new List<string> { "control /name Microsoft.AutoPlay" });
        public static ControlPanelApplet BackupAndRestoreWindows7 = new ControlPanelApplet("Backup and Restore (Windows 7)", new List<string> { "control /name Microsoft.BackupAndRestoreCenter" });
        public static ControlPanelApplet BitLockerDriveEncryption = new ControlPanelApplet("BitLocker Drive Encryption", new List<string> { "control /name Microsoft.BitLockerDriveEncryption" });
        public static ControlPanelApplet BluetoothSettingsOptionsTab = new ControlPanelApplet("Bluetooth Settings (Options tab)", new List<string> { "rundll32.exe shell32.dll,Control_RunDLL bthprops.cpl,,1" });
        public static ControlPanelApplet BluetoothSettingsCOMPortsTab = new ControlPanelApplet("Bluetooth Settings (COM Ports tab)", new List<string> { "rundll32.exe shell32.dll,Control_RunDLL bthprops.cpl,,2" });
        public static ControlPanelApplet BluetoothSettingsHardwareTab = new ControlPanelApplet("Bluetooth Settings (Hardware tab)", new List<string> { "rundll32.exe shell32.dll,Control_RunDLL bthprops.cpl,,3" });
        public static ControlPanelApplet ColorAndAppearance = new ControlPanelApplet("Color and Appearance", new List<string> { "shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921} -Microsoft.Personalization\\pageColorization" });
        public static ControlPanelApplet ColorManagement = new ControlPanelApplet("Color Management", new List<string> { "control /name Microsoft.ColorManagement" });
        public static ControlPanelApplet CredentialManager = new ControlPanelApplet("Credential Manager", new List<string> { "control /name Microsoft.CredentialManager" });
        public static ControlPanelApplet DateAndTime = new ControlPanelApplet("Date and Time", new List<string> { "control /name Microsoft.DateAndTime", "control timedate.cpl", "control date/time", "rundll32 shell32.dll,Control_RunDLL timedate.cpl,,0" });
        public static ControlPanelApplet DateAndTimeAdditionalClocks = new ControlPanelApplet("Date and Time (Additional Clocks)", new List<string> { "rundll32 shell32.dll,Control_RunDLL timedate.cpl,,1" });
        public static ControlPanelApplet DefaultPrograms = new ControlPanelApplet("Default Programs", new List<string> { "control /name Microsoft.DefaultPrograms" });
        public static ControlPanelApplet DesktopBackground = new ControlPanelApplet("Desktop Background", new List<string> { "shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921} -Microsoft.Personalization\\pageWallpaper" });
        public static ControlPanelApplet DesktopIconSettings = new ControlPanelApplet("Desktop Icon Settings", new List<string> { "rundll32 shell32.dll,Control_RunDLL desk.cpl,,0" });
        public static ControlPanelApplet DeviceManager = new ControlPanelApplet("Device Manager", new List<string> { "control /name Microsoft.DeviceManager", "control hdwwiz.cpl", "devmgmt.msc" });
        public static ControlPanelApplet DevicesAndPrinters = new ControlPanelApplet("Devices and Printers", new List<string> { "shell:::{A8A91A66-3A7D-4424-8D24-04E180695C7A}" });
        public static ControlPanelApplet EaseOfAccessCenter = new ControlPanelApplet("Ease of Access Center", new List<string> { "control /name Microsoft.EaseOfAccessCenter", "control access.cpl" });
        public static ControlPanelApplet FileExplorerOptionsGeneralTab = new ControlPanelApplet("File Explorer Options (General tab)", new List<string> { "control /name Microsoft.FolderOptions", "control folders", "rundll32 shell32.dll,Options_RunDLL 0" });
        public static ControlPanelApplet FileExplorerOptionsViewTab = new ControlPanelApplet("File Explorer Options (View tab)", new List<string> { "rundll32 shell32.dll,Options_RunDLL 7" });
        public static ControlPanelApplet FileExplorerOptionsSearchTab = new ControlPanelApplet("File Explorer Options (Search tab)", new List<string> { "rundll32 shell32.dll,Options_RunDLL 2" });
        public static ControlPanelApplet FileHistory = new ControlPanelApplet("File History", new List<string> { "control /name Microsoft.FileHistory" });
        public static ControlPanelApplet Fonts = new ControlPanelApplet("Fonts", new List<string> { "control /name Microsoft.Fonts", "control fonts" });
        public static ControlPanelApplet GameControllers = new ControlPanelApplet("Game Controllers", new List<string> { "control /name Microsoft.GameControllers", "control joy.cpl" });
        public static ControlPanelApplet GetPrograms = new ControlPanelApplet("Get Programs", new List<string> { "control /name Microsoft.GetPrograms", "rundll32 shell32.dll,Control_RunDLL appwiz.cpl,,1" });
        public static ControlPanelApplet IndexingOptions = new ControlPanelApplet("Indexing Options", new List<string> { "control /name Microsoft.IndexingOptions", "rundll32 shell32.dll,Control_RunDLL srchadmin.dll" });
        public static ControlPanelApplet Infrared = new ControlPanelApplet("Infrared", new List<string> { "control /name Microsoft.Infrared", "control irprops.cpl", "control /name Microsoft.InfraredOptions" });
        public static ControlPanelApplet InternetPropertiesGeneralTab = new ControlPanelApplet("Internet Properties (General tab)", new List<string> { "control /name Microsoft.InternetOptions", "control inetcpl.cpl", "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,0" });
        public static ControlPanelApplet InternetPropertiesSecurityTab = new ControlPanelApplet("Internet Properties (Security tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,1" });
        public static ControlPanelApplet InternetPropertiesPrivacyTab = new ControlPanelApplet("Internet Properties (Privacy tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,2" });
        public static ControlPanelApplet InternetPropertiesContentTab = new ControlPanelApplet("Internet Properties (Content tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,3" });
        public static ControlPanelApplet InternetPropertiesConnectionsTab = new ControlPanelApplet("Internet Properties (Connections tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,4" });
        public static ControlPanelApplet InternetPropertiesProgramsTab = new ControlPanelApplet("Internet Properties (Programs tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,5" });
        public static ControlPanelApplet InternetPropertiesAdvancedTab = new ControlPanelApplet("Internet Properties (Advanced tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL inetcpl.cpl,,6" });
        public static ControlPanelApplet iSCSIInitiator = new ControlPanelApplet("iSCSI Initiator", new List<string> { "control /name Microsoft.iSCSIInitiator" });
        public static ControlPanelApplet KeyboardProperties = new ControlPanelApplet("Keyboard Properties", new List<string> { "control /name Microsoft.Keyboard", "control keyboard" });
        public static ControlPanelApplet MousePropertiesButtonsTab0 = new ControlPanelApplet("Mouse Properties (Buttons tab 0)", new List<string> { "control /name Microsoft.Mouse", "control main.cpl", "control mouse", "rundll32 shell32.dll,Control_RunDLL main.cpl,,0" });
        public static ControlPanelApplet MousePropertiesPointersTab1 = new ControlPanelApplet("Mouse Properties (Pointers tab 1)", new List<string> { "control main.cpl,,1", "rundll32 shell32.dll,Control_RunDLL main.cpl,,1" });
        public static ControlPanelApplet MousePropertiesPointerOptionsTab2 = new ControlPanelApplet("Mouse Properties (Pointer Options tab 2)", new List<string> { "control main.cpl,,2", "rundll32 shell32.dll,Control_RunDLL main.cpl,,2" });
        public static ControlPanelApplet MousePropertiesWheelTab3 = new ControlPanelApplet("Mouse Properties (Wheel tab 3)", new List<string> { "control main.cpl,,3", "rundll32 shell32.dll,Control_RunDLL main.cpl,,3" });
        public static ControlPanelApplet MousePropertiesHardwareTab4 = new ControlPanelApplet("Mouse Properties (Hardware tab 4)", new List<string> { "control main.cpl,,4", "rundll32 shell32.dll,Control_RunDLL main.cpl,,4" });
        public static ControlPanelApplet NetworkAndSharingCenter = new ControlPanelApplet("Network and Sharing Center", new List<string> { "control /name Microsoft.NetworkAndSharingCenter" });
        public static ControlPanelApplet NetworkConnections = new ControlPanelApplet("Network Connections", new List<string> { "control ncpa.cpl", "control netconnections" });
        public static ControlPanelApplet NetworkSetupWizard = new ControlPanelApplet("Network Setup Wizard", new List<string> { "control netsetup.cpl" });
        public static ControlPanelApplet NotificationAreaIcons = new ControlPanelApplet("Notification Area Icons", new List<string> { "shell:::{05d7b0f4-2121-4eff-bf6b-ed3f69b894d9}" });
        public static ControlPanelApplet ODBCDataSourceAdministrator = new ControlPanelApplet("ODBC Data Source Administrator", new List<string> { "control odbccp32.cpl" });
        public static ControlPanelApplet OfflineFiles = new ControlPanelApplet("Offline Files", new List<string> { "control /name Microsoft.OfflineFiles" });
        public static ControlPanelApplet PenAndTouch = new ControlPanelApplet("Pen and Touch", new List<string> { "rundll32.exe shell32.dll,Control_RunDLL tabletpc.cpl" });
        public static ControlPanelApplet PenAndTouchPenOptionsTab = new ControlPanelApplet("Pen and Touch (Pen Options tab)", new List<string> { "rundll32.exe shell32.dll,Control_RunDLL tabletpc.cpl,,0" });
        public static ControlPanelApplet PenAndTouchTouchTab = new ControlPanelApplet("Pen and Touch (Touch tab)", new List<string> { "rundll32.exe shell32.dll,Control_RunDLL tabletpc.cpl,,1" });
        public static ControlPanelApplet PerformanceOptionsVisualEffects = new ControlPanelApplet("Performance Options (Visual Effects)", new List<string> { "%windir%\\system32\\SystemPropertiesPerformance.exe" });
        public static ControlPanelApplet PerformanceOptionsDataExecutionPrevention = new ControlPanelApplet("Performance Options (Data Execution Prevention)", new List<string> { "%windir%\\system32\\SystemPropertiesDataExecutionPrevention.exe" });
        public static ControlPanelApplet Personalization = new ControlPanelApplet("Personalization", new List<string> { "shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}" });
        public static ControlPanelApplet PhoneAndModem = new ControlPanelApplet("Phone and Modem", new List<string> { "control /name Microsoft.PhoneAndModem", "control telephon.cpl" });
        public static ControlPanelApplet PowerOptions = new ControlPanelApplet("Power Options", new List<string> { "control /name Microsoft.PowerOptions", "control powercfg.cpl" });
        public static ControlPanelApplet PowerOptionsAdvancedSettings = new ControlPanelApplet("Power Options - Advanced settings", new List<string> { "control powercfg.cpl,,1" });
        public static ControlPanelApplet PowerOptionsCreateAPowerPlan = new ControlPanelApplet("Power Options - Create a Power Plan", new List<string> { "control /name Microsoft.PowerOptions /page pageCreateNewPlan" });
        public static ControlPanelApplet PowerOptionsEditPlanSettings = new ControlPanelApplet("Power Options - Edit Plan Settings", new List<string> { "control /name Microsoft.PowerOptions /page pagePlanSettings" });
        public static ControlPanelApplet PowerOptionsSystemSettings = new ControlPanelApplet("Power Options - System Settings", new List<string> { "control /name Microsoft.PowerOptions /page pageGlobalSettings" });
        public static ControlPanelApplet PresentationSettings = new ControlPanelApplet("Presentation Settings", new List<string> { "%windir%\\system32\\PresentationSettings.exe" });
        public static ControlPanelApplet ProgramsAndFeatures = new ControlPanelApplet("Programs and Features", new List<string> { "control /name Microsoft.ProgramsAndFeatures", "control appwiz.cpl" });
        public static ControlPanelApplet Recovery = new ControlPanelApplet("Recovery", new List<string> { "control /name Microsoft.Recovery" });
        public static ControlPanelApplet RegionFormatsTab = new ControlPanelApplet("Region (Formats tab)", new List<string> { "control /name Microsoft.RegionAndLanguage", "control intl.cpl", "control international" });
        public static ControlPanelApplet RemoteAppAndDesktopConnections = new ControlPanelApplet("RemoteApp and Desktop Connections", new List<string> { "control /name Microsoft.RemoteAppAndDesktopConnections" });
        public static ControlPanelApplet ScannersAndCameras = new ControlPanelApplet("Scanners and Cameras", new List<string> { "control /name Microsoft.ScannersAndCameras", "control sticpl.cpl" });
        public static ControlPanelApplet ScreenSaverSettings = new ControlPanelApplet("Screen Saver Settings", new List<string> { "rundll32 shell32.dll,Control_RunDLL desk.cpl,,1" });
        public static ControlPanelApplet SecurityAndMaintenance = new ControlPanelApplet("Security and Maintenance", new List<string> { "control /name Microsoft.ActionCenter", "control wscui.cpl" });
        public static ControlPanelApplet SoundPlaybackTab = new ControlPanelApplet("Sound (Playback tab)", new List<string> { "control /name Microsoft.Sound", "control mmsys.cpl", "rundll32 shell32.dll,Control_RunDLL mmsys.cpl,,0" });
        public static ControlPanelApplet SoundRecordingTab = new ControlPanelApplet("Sound (Recording tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL mmsys.cpl,,1" });
        public static ControlPanelApplet SoundSoundsTab = new ControlPanelApplet("Sound (Sounds tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL mmsys.cpl,,2" });
        public static ControlPanelApplet SoundCommunicationsTab = new ControlPanelApplet("Sound (Communications tab)", new List<string> { "rundll32 shell32.dll,Control_RunDLL mmsys.cpl,,3" });
        public static ControlPanelApplet SpeechRecognition = new ControlPanelApplet("Speech Recognition", new List<string> { "control /name Microsoft.SpeechRecognition" });
        public static ControlPanelApplet StorageSpaces = new ControlPanelApplet("Storage Spaces", new List<string> { "control /name Microsoft.StorageSpaces" });
        public static ControlPanelApplet SyncCenter = new ControlPanelApplet("Sync Center", new List<string> { "control /name Microsoft.SyncCenter" });
        public static ControlPanelApplet SystemIcons = new ControlPanelApplet("System Icons", new List<string> { "shell:::{05d7b0f4-2121-4eff-bf6b-ed3f69b894d9} \\SystemIcons,,0" });
        public static ControlPanelApplet SystemPropertiesComputerName = new ControlPanelApplet("System Properties (Computer Name)", new List<string> { "%windir%\\System32\\SystemPropertiesComputerName.exe" });
        public static ControlPanelApplet SystemPropertiesHardware = new ControlPanelApplet("System Properties (Hardware)", new List<string> { "%windir%\\System32\\SystemPropertiesHardware.exe" });
        public static ControlPanelApplet SystemPropertiesAdvanced = new ControlPanelApplet("System Properties (Advanced)", new List<string> { "%windir%\\System32\\SystemPropertiesAdvanced.exe" });
        public static ControlPanelApplet SystemPropertiesSystemProtection = new ControlPanelApplet("System Properties (System Protection)", new List<string> { "%windir%\\System32\\SystemPropertiesProtection.exe" });
        public static ControlPanelApplet SystemPropertiesRemote = new ControlPanelApplet("System Properties (Remote)", new List<string> { "%windir%\\System32\\SystemPropertiesRemote.exe" });
        public static ControlPanelApplet TabletPCSettings = new ControlPanelApplet("Tablet PC Settings", new List<string> { "control /name Microsoft.TabletPCSettings" });
        public static ControlPanelApplet TextServicesAndInputLanguages = new ControlPanelApplet("Text Services and Input Languages", new List<string> { "rundll32 Shell32.dll,Control_RunDLL input.dll,,{C07337D3-DB2C-4D0B-9A93-B722A6C106E2}" });
        public static ControlPanelApplet TextToSpeech = new ControlPanelApplet("Text to Speech", new List<string> { "control /name Microsoft.TextToSpeech" });
        public static ControlPanelApplet Troubleshooting = new ControlPanelApplet("Troubleshooting", new List<string> { "shell:::{26EE0668-A00A-44D7-9371-BEB064C98683}\\0\\::{C58C4893-3BE0-4B45-ABB5-A63E4B8C8651}" });
        public static ControlPanelApplet UserAccounts = new ControlPanelApplet("User Accounts", new List<string> { "control /name Microsoft.UserAccounts", "control userpasswords" });
        public static ControlPanelApplet UserAccountsnetplwiz = new ControlPanelApplet("User Accounts (netplwiz)", new List<string> { "netplwiz", "control userpasswords2" });
        public static ControlPanelApplet WindowsDefenderFirewall = new ControlPanelApplet("Windows Defender Firewall", new List<string> { "netplwiz", "control /name Microsoft.WindowsFirewall", "control firewall.cpl" });
        public static ControlPanelApplet WindowsDefenderFirewallAllowedApps = new ControlPanelApplet("Windows Defender Firewall Allowed apps", new List<string> { "shell:::{4026492F-2F69-46B8-B9BF-5654FC07E423} -Microsoft.WindowsFirewall\\pageConfigureApps" });
        public static ControlPanelApplet WindowsDefenderFirewallWithAdvancedSecurity = new ControlPanelApplet("Windows Defender Firewall with Advanced Security", new List<string> { "%WinDir%\\System32\\WF.msc" });
        public static ControlPanelApplet WindowsFeatures = new ControlPanelApplet("Windows Features", new List<string> { "%windir%\\System32\\OptionalFeatures.exe", "rundll32 shell32.dll,Control_RunDLL appwiz.cpl,,2" });
        public static ControlPanelApplet WindowsMobilityCenter = new ControlPanelApplet("Windows Mobility Center", new List<string> { "control /name Microsoft.MobilityCenter" });
        public static ControlPanelApplet WindowsTools = new ControlPanelApplet("Windows Tools", new List<string> { "control /name Microsoft.AdministrativeTools", "control admintools" });
        public static ControlPanelApplet WorkFolders = new ControlPanelApplet("Work Folders", new List<string> { "%windir%\\System32\\WorkFolders.exe" });
    }
}