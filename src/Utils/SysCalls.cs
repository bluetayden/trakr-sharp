using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using System.Data;
using System.Management;
using System.Diagnostics;
using System.IO;

using Newtonsoft.Json;

namespace trakr_sharp.Utils {
    class SysCalls {
        private static readonly string _settingsJsonPath = "user_data/settings.json";

        private static readonly string[] _ignoredProcs = new string[] {"System Idle Process", "explorer.exe", "smss.exe",
            "taskmgr.exe", "spoolsv.exe", "lsass.exe", "csrss.exe", "winlogon.exe", "svchost.exe", "System",
            "Registry", "WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe", "conhost.exe" };

        // Creates a json to store user settings if it doens't exist
        public static void InitUserSettings() {
            // Create user_data folder if not exists
            Directory.CreateDirectory("user_data");

            // Create settings.json if not exists
            if (!File.Exists(_settingsJsonPath)) {
                UserSettings userSettings = new UserSettings {
                    CloseBehaviour = 1,
                    RunOnStartup = false,
                    ShowUtilCols = false
                };

                // Convert userSettings to json string and write to "user_data/settings.json"
                using (StreamWriter file = File.CreateText(_settingsJsonPath)) {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, userSettings);
                }
            }
        }

        // Reads "user_data/settings.json" and returns a UserSettings object
        public static UserSettings ReadUserSettings() {
            UserSettings userSettings;

            // Deserialize JSON in "user_data/settings.json" and save to 'userSettings'
            using (StreamReader file = File.OpenText(_settingsJsonPath)) {
                JsonSerializer serializer = new JsonSerializer();
                userSettings = (UserSettings)serializer.Deserialize(file, typeof(UserSettings));
            }

            return userSettings;
        }

        // Writes changes to "user_data/settings.json"
        public static void UpdateUserSettings(UserSettings newUserSettings) {
            // Read "user_data/settings/json" and save deserialzied obj in jsonObj
            string diskString = File.ReadAllText(_settingsJsonPath);
            dynamic diskUserSettings = JsonConvert.DeserializeObject(diskString);

            // Write changes from newUserSettings to jsonUserSettings
            diskUserSettings["CloseBehaviour"] = newUserSettings.CloseBehaviour;
            diskUserSettings["RunOnStartup"] = newUserSettings.RunOnStartup;
            diskUserSettings["ShowUtilCols"] = newUserSettings.ShowUtilCols;

            // Write changes to back to file
            string outputJson = JsonConvert.SerializeObject(diskUserSettings);
            File.WriteAllText(_settingsJsonPath, outputJson);
        }

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

        // Return a dict that contains paths to exe files with proc_names as keys. (Uses selectedProcs as a predicate).
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

            // Add items that were not found by WMI (process likely closed while AddRecordsForm was open)
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

        public static Icon GetIconFromPath(string path) {
            Icon ico = null;

            try {
                ico = Icon.ExtractAssociatedIcon(path);
            }
            catch (Exception) {
                Utils.SysCalls.Print("File could not be found or is inaccessible");
            }

            return ico;
        }

        public static void CacheIconsToDisk(Dictionary<string, string> procPathPairs, bool overwrite=false) {
            // Create cache folder if not exists
            System.IO.Directory.CreateDirectory("cache");

            foreach (string name in procPathPairs.Keys) {
                string imgPath = String.Format("cache/{0}.png", name.Substring(0, name.Length - 4));

                // If icon not already cached, or overwrite is true
                if (!System.IO.File.Exists(imgPath) || overwrite) {
                    // Get icon from path
                    using (Icon ico = GetIconFromPath(procPathPairs[name])) {
                        // If the icon does already exist in the cache, delete it to prevent GDI error
                        if (System.IO.File.Exists(imgPath)) {
                            System.IO.File.Delete(imgPath);
                        }

                        // If the icon was successfully found, save it to cache
                        if (ico != null) {
                            ico.ToBitmap().Save(imgPath);
                        }
                    }
                }
            }
        }

        // Retrieves an image from the cache folder using a proc_name
        public static Bitmap GetProcBitmap(string name) {
            Bitmap retImg;

            if (name == "NO_PROC") {
                using (Bitmap img = new Bitmap("assets/proc_icon_missing.png")) {
                    retImg = new Bitmap(img);
                    return retImg;
                }
            }
            else {
                string imgPath = String.Format("cache/{0}.png", name.Substring(0, name.Length - 4));

                // If icon in cache
                if (System.IO.File.Exists(imgPath)) {
                    using (Bitmap img = new Bitmap(imgPath)) {
                        retImg = new Bitmap(img);
                        return retImg;
                    }
                }
                else {
                    using (Bitmap img = new Bitmap("assets/proc_icon_default.png")) {
                        retImg = new Bitmap(img);
                        return retImg;
                    }
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
