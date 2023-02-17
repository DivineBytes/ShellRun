$host.ui.rawui.windowtitle="PowerShell Test"

Write-Host "Hello, world!"
Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');