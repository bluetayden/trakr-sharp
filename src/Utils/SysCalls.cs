using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace trakr_sharp.Utils {
    class SysCalls {
        private static string[] ignoredProcs = new string[] {"System Idle Process", "explorer.exe", "taskmgr.exe",
                "spoolsv.exe", "lsass.exe", "csrss.exe", "smss.exe", "winlogon.exe", "svchost.exe", "services.exe",
                "System", "Registry", "WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe", "conhost.exe" };

        public static List<string> getRunningProcList() {
            // Get list of all running process names
            IEnumerable<string> runningProcs = Process.GetProcesses().Select(proc => proc.ProcessName + ".exe");

            // Filter unwanted processes from list
            IEnumerable<string> filteredProcs = runningProcs.Where(proc => !ignoredProc(proc));
            // Remove duplicates from list
            filteredProcs = filteredProcs.Distinct();
            // Order list alphabetically
            filteredProcs = filteredProcs.OrderBy(proc => proc[0]);

            return filteredProcs.ToList();
        }

        private static bool ignoredProc(string proc) {
            return ignoredProcs.Contains(proc);
        }

        public static void Print(object msg) {
            Debug.WriteLine(msg);
        }
    }
}
