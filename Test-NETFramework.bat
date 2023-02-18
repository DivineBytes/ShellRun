@ECHO OFF

REM Enable support for UTF-8 Unicode
CHCP 65001 > NUL

TITLE %ConsoleTitle%

SET program="ShellRun\bin\Debug\ShellRun.dll"

"%program%" "code" "csharp" "AppName" "null" "ShellRun.Test\Code\CSharp\Program.cs;ShellRun.Test\Code\CSharp\Utilities.cs"
REM "%program%" "code" "visualbasic" "AppName" "null" "ShellRun.Test\Code\VisualBasic\Program.vb"

ECHO.
PAUSE > NUL | SET /P = "Press any Key to exit..."