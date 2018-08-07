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
            Print(bytes, "\\\\" + System.Environment.MachineName + "\\RONGTA");
        }

        public static void Print(byte[] bytes, string port)
        {
            //var filePath = desktopPath + "\\Posprint\\tmpPrint.print";
            var filePath = Path.Combine(GetFolderPath(), "tmpPrint.print");
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.WriteAllBytes(filePath, bytes);
            File.Move(filePath, port);
        }

        public static string GetFolderPath()
        {
            var desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            var folderPath = Path.Combine(desktopPath, "Posprint");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
    }
}

