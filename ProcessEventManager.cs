using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;

namespace ProcessStartWatcher
{
    public class ProcessEventManager
    {
        public ProcessEventManager()
        {
            Watcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            Watcher.EventArrived += Watcher_EventArrived;
            Watcher.Start();
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                var process = Process.GetProcessById(Convert.ToInt32(e.NewEvent.Properties["ProcessId"].Value));
                OnProcessStarted.Invoke(process);
            }
            catch {   }
        }

        ManagementEventWatcher Watcher;

        public delegate void ProcessStarted(Process process);
        public event ProcessStarted OnProcessStarted;
    }
}
