using System;
using System.Text;

namespace AppName
{
    public class Utilities
    {
        public static void ShowDescription()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Name: AppName");
            stringBuilder.AppendLine("Version: 1.0.0.0");
            stringBuilder.AppendLine("Path: C:\\AppName.exe");

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}