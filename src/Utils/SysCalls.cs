﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using System.Data;
using System.Management;
using System.Diagnostics;

namespace trakr_sharp.Utils {
    class SysCalls {
        private static readonly string[] _ignoredProcs = new string[] {"System Idle Process", "explorer.exe", "smss.exe",
            "taskmgr.exe", "spoolsv.exe", "lsass.exe", "csrss.exe", "winlogon.exe", "svchost.exe", "System",
            "Registry", "WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe", "conhost.exe" };

        // List of currently running processes on the device
        public static List<string> GetRunningProcNameList(bool incDuplicates = false) {
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
        public static List<string> GetRunningUntrackedProcNameList() {
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

        // Dict that contains paths to exe files with provided proc_names as a key
        public static Dictionary<string, string> GetProcPathPairs(List<string> selectedProcs) {
            Dictionary<string, string> procPathPairs = new Dictionary<string, string>();

            ManagementObjectSearcher mo_searcher = new ManagementObjectSearcher("SELECT Name, ExecutablePath FROM Win32_Process");
            // Execute the query provided in mo_searcher above
            ManagementObjectCollection mo_results = mo_searcher.Get();
            // Get list of { name, path } from mo_results that have Names that match anything in Process.GetProcesses()
            var proc_path_results = from p in Process.GetProcesses()
                                    join mo in mo_results.Cast<ManagementObject>()
                                    on (p.ProcessName + ".exe") equals (string)mo["Name"]
                                    select new {
                                        Name = p.ProcessName + ".exe",
                                        Path = (string)mo["ExecutablePath"],
                                    };

            // If a pair has a name in selectedProcs is and not in the dict yet, add it
            foreach (var item in proc_path_results) {
                if (selectedProcs.Contains(item.Name) && !procPathPairs.ContainsKey(item.Name)) {
                    procPathPairs.Add(item.Name, item.Path);
                }
            }

            // Add items that were not found by WMI (process likely closed while AddProgramsForm was open)
            foreach (string proc_name in selectedProcs) {
                if (!procPathPairs.ContainsKey(proc_name)) {
                    procPathPairs.Add(proc_name, "");
                }
            }

            mo_searcher.Dispose(); // Manual disposal required to stop WMI mem leaks
            mo_results.Dispose();

            return procPathPairs;
        }

        // List of <string name, int count> of currently running process on the device that are being tracked in the db
        public static Dictionary<string, int> GetRunningTrackedPairs() {
            List<string> trackedProcs = Utils.Database.GetProcessNameList();

            // Filter currently running process to only contain those being tracked (include duplicates)
            trackedProcs = GetRunningProcNameList(true).Where(proc => trackedProcs.Contains(proc)).ToList();

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

        private static Icon GetIconFromPath(string path) {
            Icon ico = null;

            try {
                ico = Icon.ExtractAssociatedIcon(path);
            }
            catch (Exception) {
                Utils.SysCalls.Print("File could not be found or is inaccessible");
            }

            return ico;
        }

        public static void CacheIconsToDisk(Dictionary<string, string> procPathPairs) {
            // Create cache folder if not exists
            System.IO.Directory.CreateDirectory("cache");

            foreach (string name in procPathPairs.Keys) {
                string imgPath = String.Format("cache/{0}.png", name.Substring(0, name.Length - 4));

                // If icon not already cached
                if (!System.IO.File.Exists(imgPath)) {
                    // Get icon from path
                    using (Icon ico = GetIconFromPath(procPathPairs[name])) {
                        // If the icon was successfully found, save it to cache
                        if (ico != null) {
                            ico.ToBitmap().Save(imgPath);
                        }
                    }
                }
            }
        }

        // Retrieves an image from the cache folder using a proc_name
        public static Image GetProcImage(string name) {
            if (name == "NO_PROC") {
                return Image.FromFile("assets/proc_icon_missing.png");
            }
            else {
                string imgPath = String.Format("cache/{0}.png", name.Substring(0, name.Length - 4));
                Image img = null;

                // If icon in cache
                if (System.IO.File.Exists(imgPath)) {
                    img = Image.FromFile(imgPath);
                }
                else {
                    img = Image.FromFile("assets/proc_icon_default.png");
                }

                return img;
            }
        }

        public static void Print(object msg) {
            #if DEBUG
                Debug.WriteLine(msg);
            #endif
        }
    }
}
