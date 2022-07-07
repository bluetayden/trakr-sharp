using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using System.Data;
using System.Management;
using System.Diagnostics;
using System.IO;

using Newtonsoft.Json;

namespace trakr_sharp.Utils {
    class SysCalls {
        private static readonly string _settingsJsonPath = "user_data/settings.json";
        private static readonly string _screenshotsPath = "user_data/screenshots";
        private static readonly string _readmePath = "README.md";

        private static readonly string[] _ignoredProcs = new string[] { "System Idle Process", "explorer.exe", "smss.exe",
            "taskmgr.exe", "spoolsv.exe", "lsass.exe", "csrss.exe", "winlogon.exe", "svchost.exe", "System",
            "Registry", "WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe", "conhost.exe" };

        /// <summary>
        /// Creates a JSON to store user settings if it doens't exist
        /// </summary>
        public static void InitUserSettings() {
            // Create user_data folder if not exists
            Directory.CreateDirectory("user_data");

            // Create settings.json if not exists
            if (!File.Exists(_settingsJsonPath)) {
                UserSettings userSettings = UserSettings.Default;
                // Convert userSettings to json string and write to "user_data/settings.json"
                using (StreamWriter file = File.CreateText(_settingsJsonPath)) {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, userSettings);
                }
            }
        }

        /// <summary>
        /// Reads "user_data/settings.json" and returns a UserSettings object
        /// </summary>
        public static UserSettings ReadUserSettings() {
            UserSettings userSettings;

            // Deserialize JSON in "user_data/settings.json" and save to 'userSettings'
            using (StreamReader file = File.OpenText(_settingsJsonPath)) {
                JsonSerializer serializer = new JsonSerializer();
                userSettings = (UserSettings)serializer.Deserialize(file, typeof(UserSettings));
            }

            return userSettings;
        }

        /// <summary>
        /// Writes the provided UserSettings obj to "user_data/settings.json"
        /// </summary>
        public static void UpdateUserSettings(UserSettings newUserSettings) {
            // Read "user_data/settings/json" and save deserialzied obj in jsonObj
            string diskString = File.ReadAllText(_settingsJsonPath);
            dynamic diskUserSettings = JsonConvert.DeserializeObject(diskString);

            // Write changes from newUserSettings to jsonUserSettings
            diskUserSettings["OnClose"] = (int)newUserSettings.OnClose;
            diskUserSettings["RunOnStartup"] = newUserSettings.RunOnStartup;
            diskUserSettings["EnableScreenshots"] = newUserSettings.EnableScreenshots;
            diskUserSettings["ShowUtilCols"] = newUserSettings.ShowUtilCols;

            // Write changes to back to file
            string outputJson = JsonConvert.SerializeObject(diskUserSettings);
            File.WriteAllText(_settingsJsonPath, outputJson);
        }

        /// <summary>
        /// Creates the user_data folder if it doesn't exist
        /// </summary>
        public static void InitScreenshotsDir() {
            Directory.CreateDirectory(_screenshotsPath);
        }

        /// <summary>
        /// Attempts to take and saves screenshot of the current display
        /// </summary>
        /// <returns>[String] The path the image was saved to, or a failure message</returns>
        public static string TakeScreenshot() {
            string fileName = Guid.NewGuid().ToString() + ".png";
            string filePath = string.Format("{0}/{1}", _screenshotsPath, fileName);

            // Make sure screenshot with chosen GUID does not exist
            while (File.Exists(filePath)) {
                fileName = Guid.NewGuid().ToString() + ".png";
                filePath = string.Format("{0}/{1}", _screenshotsPath, fileName);
            }

            // Take screenshot and try to save it
            try {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
                    using (Graphics g = Graphics.FromImage(bitmap)) {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    bitmap.Save(filePath, ImageFormat.Png);
                }

                return string.Format("Screenshot saved to {0}", filePath);
            }
            catch (Exception) {
                return "Failed to save screenshot";
            }
        }

        /// <summary>
        /// Opens the "README.md" file with notepad
        /// </summary>
        public static bool OpenReadme() {
            try {
                Process.Start("notepad.exe", _readmePath);
                return true;
            }
            catch(Exception) {
                return false;
            }
        }

        /// <summary>
        /// Opens the trakr-sharp repo link in a browser window
        /// </summary>
        public static bool OpenRepoLink() {
            try {
                Process.Start("https://github.com/bluetayden/trakr-sharp");
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Returns a list of processes currently running on the device
        /// </summary>
        public static List<string> GetRunningProcNameList(bool distinct = true) {
            // Get list of all running process names
            IEnumerable<string> runningProcs = Process.GetProcesses().Select(proc => proc.ProcessName + ".exe");
            // Filter unwanted processes (and duplicates if requested)
            IEnumerable<string> filteredProcs = runningProcs.Where(proc => !_ignoredProcs.Contains(proc));
            if (distinct) { filteredProcs = filteredProcs.Distinct(); }
            // Order list alphabetically
            filteredProcs = filteredProcs.OrderBy(proc => proc[0]);

            return filteredProcs.ToList();
        }

        /// <summary>
        /// Returns a list of running processes excluding ones that are already stored in the db
        /// </summary>
        public static List<string> GetRunningUntrackedProcNameList() {
            // Get list of all running process names (append .exe to each name)
            IEnumerable<string> runningProcs = Process.GetProcesses().Select(proc => proc.ProcessName + ".exe");
            // Filter unwanted processes from list
            IEnumerable<string> filteredProcs = runningProcs.Where(proc => !_ignoredProcs.Contains(proc));
            // Get list of processes stored in db and filter stored procs out
            List<string> storedProcs = Database.GetProcessNameList();
            filteredProcs = filteredProcs.Where(proc => !storedProcs.Contains(proc));
            // Remove duplicates and order alphabetically
            filteredProcs = filteredProcs.Distinct();
            filteredProcs = filteredProcs.OrderBy(proc => proc[0]);

            return filteredProcs.ToList();
        }

        /// <summary>
        /// Returns a dict that contains paths to exe files with proc_names as keys. (Uses selectedProcs as a predicate).
        /// </summary>
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

        /// <summary>
        /// List of [string name, int count] of currently running process on the device, that are also being tracked in the db
        /// </summary>
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

                // If icon not already cached, or overwriting is enabled
                if (!System.IO.File.Exists(imgPath) || overwrite) {
                    // Get icon from path
                    using (Icon ico = GetIconFromPath(procPathPairs[name])) {
                        // If the icon does already exist in the cache, delete it to prevent GDI error
                        if (overwrite && System.IO.File.Exists(imgPath)) {
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

        /// <summary>
        /// Retrieves an image from the cache folder using a proc_name
        /// </summary>
        public static Bitmap GetIconFromCache(string name) {
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
