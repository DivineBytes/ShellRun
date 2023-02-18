Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace AppName

    Module Program

        Public Sub Main()

            'ShowDescription()
            'Add(5, 66)
            Console.ReadKey()

        End Sub

        Function Add(ByVal x As Integer, ByVal y As Integer) As Integer
            Dim Res As Integer
            Res = x + y
        End Function

        Public Sub ShowDescription()

            'StringBuilder StringBuilder = New StringBuilder();
            'StringBuilder.AppendLine("Name: AppName");
            'StringBuilder.AppendLine("Version: 1.0.0.0");
            'StringBuilder.AppendLine("Path: C:\\AppName.exe");

            'Console.WriteLine(StringBuilder.ToString());
            Console.WriteLine("Hello, world!")

        End Sub

    End Module

End Namespace