using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessStartWatcher
{
    class Program
    {
        public static void Main(string[] args)
        {
            new ProcessEventManager().OnProcessStarted += Manager_OnProcessStarted;
            Console.ReadKey();
        }

        private static void Manager_OnProcessStarted(Process process)
        {
            if (process.MainWindowTitle == String.Empty)
            {
                Console.WriteLine($"[{DateTime.Now}] {process.ProcessName}");
            }
            else
            {
                Console.WriteLine($"[{DateTime.Now}] {process.MainWindowTitle}");
            }
        }
    }
}
