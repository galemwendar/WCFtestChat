using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestChat_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCFtest.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Хост запустился!");
                Console.ReadLine();
            }
        }
    }
}
