using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace trakr_sharp.Utils {
    class SysCalls {
        private static readonly string[] _ignoredProcs = new string[] {"System Idle Process", "explorer.exe", "smss.exe", 
            "taskmgr.exe", "spoolsv.exe", "lsass.exe", "csrss.exe", "winlogon.exe", "svchost.exe", "System", 
            "Registry", "WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe", "conhost.exe" };

        public static List<string> GetRunningProcList() {
            // Get list of all running process names
            IEnumerable<string> runningProcs = Process.GetProcesses().Select(proc => proc.ProcessName + ".exe");

            // Filter unwanted processes from list
            IEnumerable<string> filteredProcs = runningProcs.Where(proc => !_ignoredProcs.Contains(proc));
            // Get list of processes stored in database
            List<string> storedProcs = Database.GetProcessNameList();
            // Filter stored procs from list
            filteredProcs = filteredProcs.Where(proc => !storedProcs.Contains(proc));
            // Remove duplicates from list
            filteredProcs = filteredProcs.Distinct();
            // Order list alphabetically
            filteredProcs = filteredProcs.OrderBy(proc => proc[0]);

            return filteredProcs.ToList();
        }

        public static void Print(object msg) {
            #if DEBUG
                Debug.WriteLine(msg);
            #endif
        }
    }
}
