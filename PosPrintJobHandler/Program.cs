using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PosPrintJobHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var s in args)
            {
                Console.WriteLine(s);

            }
            using (var client = new HttpClient())
            {
                var responseString = client.GetStringAsync("http://www.example.com/recepticle.aspx");
                Console.WriteLine("it executed");
                Console.ReadKey();
            }
        }
    }
}

