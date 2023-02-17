using ShellRun.Modules;
using System.Collections.Generic;

namespace ShellRun.Containers
{
    /// <summary>
    /// The <see cref="MMC"/> class.
    /// </summary>
#pragma warning disable 1591

    public static class MMC
    {
        public static MicrosoftManagementConsole ADDomainsAndTrusts = new MicrosoftManagementConsole("AD Domains and Trusts", "Domain.msc", new List<string> { MicrosoftManagementConsole.Category.ADConfiguration });
        public static MicrosoftManagementConsole ADSIEdit = new MicrosoftManagementConsole("ADSI Edit", "ADSIedit.msc", new List<string> { MicrosoftManagementConsole.Category.ADConfiguration });
        public static MicrosoftManagementConsole ADSitesAndServices = new MicrosoftManagementConsole("AD Sites and Services", "DSsite.msc", new List<string> { MicrosoftManagementConsole.Category.ADConfiguration });
        public static MicrosoftManagementConsole ADUsersAndComputers = new MicrosoftManagementConsole("AD Users and Computers", "DSA.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole AuthorizationManager = new MicrosoftManagementConsole("Authorization Manager", "AZman.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole CertificatesManagementCurrentUser = new MicrosoftManagementConsole("Certificates Management - Current user", "Certmgr.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole CertificatesManagementLocalMachine = new MicrosoftManagementConsole("Certificates Management - Local machine", "Certlm.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole CertificateTemplates = new MicrosoftManagementConsole("Certificate Templates", "Certtmpl.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole CertificationAuthorityManagement = new MicrosoftManagementConsole("Certification Authority Management", "Certsrv.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole ComponentServices = new MicrosoftManagementConsole("Component Services", "Comexp.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole ComputerManagement = new MicrosoftManagementConsole("Computer Management", "Compmgmt.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole DeviceManager = new MicrosoftManagementConsole("Device Manager", "Devmgmt.msc", new List<string> { MicrosoftManagementConsole.Category.Hardware });
        public static MicrosoftManagementConsole DiskDefragmenter = new MicrosoftManagementConsole("Disk Defragmenter", "dfrgui.exe", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole DiskManager = new MicrosoftManagementConsole("Disk Manager", "DiskMgmt.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole DistributedFileServiceMgmt = new MicrosoftManagementConsole("Distributed File Service Mgmt", "DFSmgmt.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole DNSManager = new MicrosoftManagementConsole("DNS Manager", "DNSmgmt.msc", new List<string> { MicrosoftManagementConsole.Category.Network });
        public static MicrosoftManagementConsole EmbeddedLockdownManager = new MicrosoftManagementConsole("Embedded Lockdown Manager", "EmbeddedLockdown.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole EventViewer = new MicrosoftManagementConsole("Event Viewer", "Eventvwr.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole FailoverClusterManager = new MicrosoftManagementConsole("Failover cluster Manager", "Cluadmin.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole FileServerResourceManager = new MicrosoftManagementConsole("File Server Resource manager", "FSRM.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole GroupPolicyManagement = new MicrosoftManagementConsole("Group Policy Management", "GPmc.msc", new List<string> { MicrosoftManagementConsole.Category.Policy });
        public static MicrosoftManagementConsole GroupPolicyManagementEditor = new MicrosoftManagementConsole("Group Policy Management Editor", "GPme.msc", new List<string> { MicrosoftManagementConsole.Category.Policy });
        public static MicrosoftManagementConsole GroupPolicyStarterGPOEditor = new MicrosoftManagementConsole("Group Policy Starter GPO Editor", "GPTedit.msc", new List<string> { MicrosoftManagementConsole.Category.Policy });
        public static MicrosoftManagementConsole LocalGroupPolicyEditor = new MicrosoftManagementConsole("Local Group Policy Editor", "GPedit.msc", new List<string> { MicrosoftManagementConsole.Category.Policy });
        public static MicrosoftManagementConsole LocalSecuritySettingsManager = new MicrosoftManagementConsole("Local Security Settings Manager", "SecPol.msc", new List<string> { MicrosoftManagementConsole.Category.Policy });
        public static MicrosoftManagementConsole LocalUsersAndGroupsManager = new MicrosoftManagementConsole("Local Users and Groups Manager", "LUsrMgr.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole NAPClientConfiguration = new MicrosoftManagementConsole("NAP client configuration", "NapCLCfg", new List<string> { MicrosoftManagementConsole.Category.Network });
        public static MicrosoftManagementConsole NotificationsStartMenuPolicy = new MicrosoftManagementConsole("Notifications/Start menu/policy", "DevModeRunAsUserConfig.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole PerformanceMonitor = new MicrosoftManagementConsole("Performance Monitor", "PerfMon.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole PrintManagement = new MicrosoftManagementConsole("Print Management", "PrintManagement.msc", new List<string> { MicrosoftManagementConsole.Category.Print });
        public static MicrosoftManagementConsole QualityOfServiceControlManagement = new MicrosoftManagementConsole("Quality of Service Control Management", "ACSsnap.msc", new List<string> { MicrosoftManagementConsole.Category.Network });
        public static MicrosoftManagementConsole RemoteDesktop = new MicrosoftManagementConsole("Remote Desktop", "TSmmc.msc", new List<string> { MicrosoftManagementConsole.Category.RemoteAccess });
        public static MicrosoftManagementConsole ResultantSetOfPolicy = new MicrosoftManagementConsole("Resultant Set of Policy", "RSOP.msc", new List<string> { MicrosoftManagementConsole.Category.Policy });
        public static MicrosoftManagementConsole ServerRolesFeatures = new MicrosoftManagementConsole("Server Roles, Features", "ServerManager.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole ServicesManagement = new MicrosoftManagementConsole("Services Management", "Services.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole SharedFoldersOpenFiles = new MicrosoftManagementConsole("Shared Folders open files", "FSmgmt.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole SQLServerConfigurationManager = new MicrosoftManagementConsole("SQL Server configuration Manager", "SQLServerManager11.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole StorageMgmt = new MicrosoftManagementConsole("Storage Mgmt", "StorageMgmt.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole TaskScheduler = new MicrosoftManagementConsole("Task Scheduler", "TaskSchd.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole TelephonyManagement = new MicrosoftManagementConsole("Telephony Management", "TAPImgmt.msc", new List<string> { MicrosoftManagementConsole.Category.PhoneModem });
        public static MicrosoftManagementConsole TeminalServicesRDP = new MicrosoftManagementConsole("Teminal Services RDP", "MSTSC", new List<string> { MicrosoftManagementConsole.Category.RemoteAccess });
        public static MicrosoftManagementConsole TeminalServicesRDPToConsole = new MicrosoftManagementConsole("Teminal Services RDP to Console", "MSTSC /v:[server] /console", new List<string> { MicrosoftManagementConsole.Category.RemoteAccess });
        public static MicrosoftManagementConsole TerminalServerManager = new MicrosoftManagementConsole("Terminal Server Manager", "TSadmin.msc", new List<string> { MicrosoftManagementConsole.Category.RemoteAccess });
        public static MicrosoftManagementConsole TrustedPlatformModule = new MicrosoftManagementConsole("Trusted Platform Module", "TPM.msc", new List<string> { MicrosoftManagementConsole.Category.Security });
        public static MicrosoftManagementConsole WindowsFirewall = new MicrosoftManagementConsole("Windows Firewall", "WF.msc", new List<string> { MicrosoftManagementConsole.Category.RemoteAccess });
        public static MicrosoftManagementConsole WindowsLocalBackup = new MicrosoftManagementConsole("Windows Local Backup", "WLBadmin.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
        public static MicrosoftManagementConsole WindowsMangementInstrumentation = new MicrosoftManagementConsole("Windows Mangement Instrumentation", "WmiMgmt.msc", new List<string> { MicrosoftManagementConsole.Category.None });
        public static MicrosoftManagementConsole WindowsServerBackupLocalRemote = new MicrosoftManagementConsole("Windows Server Backup (Local+Remote)", "WBadmin.msc", new List<string> { MicrosoftManagementConsole.Category.Disc, MicrosoftManagementConsole.Category.File });
    }
}