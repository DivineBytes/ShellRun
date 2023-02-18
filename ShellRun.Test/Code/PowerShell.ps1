$host.ui.rawui.windowtitle="PowerShell Test"

Write-Host "Hello, world!"
Write-Host -NoNewLine 'Press any Key to exit...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');