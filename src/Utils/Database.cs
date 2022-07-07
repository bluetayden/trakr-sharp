using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

using LiteDB;

namespace trakr_sharp.Utils {
    class Database {
        private static readonly string _databasePath = "user_data/tracking.db";

        private static LiteDatabase ConnectToDatabase() {
            return new LiteDatabase(_databasePath);
        }

        public static void Init() {
            // Create user_data folder if not exists
            System.IO.Directory.CreateDirectory("user_data");
            // Create db file
            using (LiteDatabase db = ConnectToDatabase()) {
                // Create 'tracked' table if doesn't exist
                db.GetCollection<ProcRecord>("tracked");
            }
        }

        /// <summary>
        /// Creates several new ProcRecords with a dictionary [string proc_name, string proc_path]
        /// </summary>
        public static void InsertProcPathPairs(Dictionary<string, string> procPathPairs) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                foreach (string name in procPathPairs.Keys) {
                    // Create instance ('record') of ProcRecord using proc_name and it's associated path
                    ProcRecord record = new ProcRecord {
                        proc_name = name,
                        program_name = name.Substring(0, name.Length - 4),
                        total_time = 0,
                        date_opened = DateTime.UtcNow.ToString("o"),
                        date_added = DateTime.UtcNow.ToString("o"),
                        proc_path = procPathPairs[name]
                    };

                    // Insert record into db collection
                    trackedCol.Insert(record);
                }
            }
        }

        /// <summary>
        /// Deletes a List of ProcRecords from the database by proc_name
        /// </summary>
        public static void DeleteProcs(List<string> proc_names) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                // Delete record with proc_name fields that are in proc_names
                trackedCol.DeleteMany(record => proc_names.Contains(record.proc_name));
            }
        }

        /// <summary>
        /// Updates the hours_used and date_opened field of every relevant proc
        /// </summary>
        public static void UpdateTotalTimes(Dictionary<string, long> procTimePairs) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                foreach (string proc_name in procTimePairs.Keys) {
                    ProcRecord proc_record = trackedCol.FindOne(record => record.proc_name == proc_name);
                    proc_record.total_time += procTimePairs[proc_name];
                    proc_record.date_opened = DateTime.UtcNow.ToString("o");

                    trackedCol.Update(proc_record);
                }
            }
        }

        /// <summary>
        /// Updates an existing record with new values (called from EditRecordForm)
        /// </summary>
        public static void UpdateRecord(ProcRecord record) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");
                // Update the relevant document with the new "record" object
                trackedCol.Update(record);
            }
        }

        /// <summary>
        /// Gets a list of every proc_name field in the database
        /// </summary>
        /// <returns></returns>
        public static List<string> GetProcessNameList() {
            List<string> procNames = new List<string>();
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");
                // Query each record in db for its proc_name, store result in procNames
                procNames.AddRange(
                    trackedCol.Query()
                        .Select(record => record.proc_name)
                        .ToList()
                );
            }

            return procNames;
        }

        /// <summary>
        /// Get a List[ProcRecord] containing every entry in the db
        /// </summary>
        public static List<ProcRecord> GetProcRecords() {
            // Get all records from db as list
            List<ProcRecord> allRecords = new List<ProcRecord>();
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");
                // Query db for each record
                allRecords = trackedCol.FindAll().ToList();
            }

            return allRecords;
        }

        /// <summary>
        /// Retrieves a ProcRecord document from the database
        /// </summary>
        public static ProcRecord GetProcRecord(string name) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");
                return trackedCol.FindOne(record => record.proc_name == name);
            }
        }

        /// <summary>
        /// Retrieves a ProcRecord document and casts it to ProcData before returning it
        /// </summary>
        public static ProcData GetProcData(string name) {
            ProcRecord record = GetProcRecord(name);
            return record.ToProcData();
        }

        /// <summary>
        /// Convert db entries to List<ProcData> for display in TrackingList
        /// </summary>
        public static List<ProcData> GetProcDataList() {
            // Get all records from db as list
            List<ProcRecord> allRecords = new List<ProcRecord>();
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");
                // Query db for each record
                allRecords = trackedCol.FindAll().ToList();
            }

            // Convert each ProcRecord to ProcData
            List<ProcData> allData = new List<ProcData>();
            foreach (ProcRecord record in allRecords) {
                ProcData new_data = record.ToProcData();
                allData.Add(new_data);
            }

            return allData;
        }
    }
}
