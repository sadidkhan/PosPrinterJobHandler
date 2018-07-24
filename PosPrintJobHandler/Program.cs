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
            //args = new string[] { "posprintjobhandler:77, 97, 109, 97, 32, 72, 97, 108, 105, 109, 10" };
            if (args.Length > 0)
            {
                var parameterString = args[0].ToString().Replace("posprintjobhandler:", "");

                if (string.IsNullOrEmpty(parameterString)) return;
                var values = parameterString.Split(',');
                if (values.Length > 0)
                {
                    var bytes = values.Select(_ => _.Trim()).Select(_ => (byte)int.Parse(_)).ToArray();
                    PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
                    Print(bytes, "\\\\Desktop-8h2b42n\\RONGTA");
                }
            }
        }

        public static void Print(byte[] bytes, string port)
        {
            var desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            var filePath = desktopPath + "\\PosPrint\\tmpPrint.print";
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.WriteAllBytes(filePath, bytes);
            File.Move(filePath, port);
        }
    }
}

