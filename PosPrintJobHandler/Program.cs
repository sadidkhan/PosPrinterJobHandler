using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using PrinterUtility;

namespace PosPrintJobHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0) return;
            var parameterString = args[0].Replace("posprintjobhandler:", "");

            if (string.IsNullOrEmpty(parameterString)) return;
            byte[] bytes = Convert.FromBase64String(parameterString);
            Print(bytes, "\\\\Desktop-8h2b42n\\RONGTA");
        }

        public static void Print(byte[] bytes, string port)
        {
            var desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            var filePath = desktopPath + "\\Posprint\\tmpPrint.print";
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.WriteAllBytes(filePath, bytes);
            File.Move(filePath, port);
        }
    }
}

