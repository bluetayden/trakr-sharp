using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;

namespace trakr_sharp.Utils {
    class SysCalls {
        private static readonly string[] _ignoredProcs = new string[] {"System Idle Process", "explorer.exe", "smss.exe",
            "taskmgr.exe", "spoolsv.exe", "lsass.exe", "csrss.exe", "winlogon.exe", "svchost.exe", "System",
            "Registry", "WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe", "conhost.exe" };

        // List of currently running processes on the device
        public static List<string> GetRunningProcList(bool incDuplicates = false) {
            // Get list of all running process names
            IEnumerable<string> runningProcs = Process.GetProcesses().Select(proc => proc.ProcessName + ".exe");

            // Filter unwanted processes from list
            IEnumerable<string> filteredProcs = runningProcs.Where(proc => !_ignoredProcs.Contains(proc));
            if (!incDuplicates) {
                // Remove duplicates from list
                filteredProcs = filteredProcs.Distinct();
            }
            // Order list alphabetically
            filteredProcs = filteredProcs.OrderBy(proc => proc[0]);

            return filteredProcs.ToList();
        }

        // List of currently running processes on the device, without procs that are already stored in the db
        public static List<string> GetRunningUntrackedProcList() {
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

        // List of <string name, int count> of currently running process on the device that are being tracked in the db
        public static Dictionary<string, int> GetRunningTrackedPairs() {
            List<string> trackedProcs = Utils.Database.GetProcessNameList();

            // Filter currently running process to only contain those being tracked (include duplicates)
            trackedProcs = GetRunningProcList(true).Where(proc => trackedProcs.Contains(proc)).ToList();

            // Store name keys in trackedPairs, and inc count for every ocurrence of a particular proc
            Dictionary<string, int> trackedPairs = new Dictionary<string, int>();

            foreach (string p in trackedProcs) {
                // If a key == p in trackedPairs, inc count
                if (trackedPairs.ContainsKey(p)) {
                    trackedPairs[p] += 1;
                }
                // Otherwise add p to trackedPairs with count 1
                else {
                    trackedPairs.Add(p, 1);
                }
            }

            return trackedPairs;
        }

        public static void PrintDataTable(DataTable table) {
            foreach (DataRow row in table.Rows) {
                foreach (var item in row.ItemArray) {
                    Print(item);
                }
            }
        }

        public static void Print(object msg) {
            #if DEBUG
                Debug.WriteLine(msg);
            #endif
        }
    }
}
