@ECHO OFF

REM Enable support for UTF-8 Unicode
CHCP 65001 > NUL

SET "AppTitle=ShellRun"
SET "AppVersion=1.0.0.0"
SET "ConsoleTitle=%AppTitle%"

TITLE %ConsoleTitle%

ECHO %AppTitle% [Version %AppVersion%]
ECHO.

REM Insert you custom code below

set myParam0=RAM
set program="ShellRun\bin\Debug\ShellRun.dll"

REM "%program%" "%myParam0%" "asd" "312"

"%program%" "compile" "AppName" "csharp" "System.dll,System.Forms.dll" "ShellRun.Test\Code\CSharp\Program.cs" "ShellRun.Test\Code\CSharp\Utilities.cs"

ECHO.
PAUSE > NUL | SET /P = "Press any Key to exit..."