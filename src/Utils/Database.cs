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

                    // Insert record into db col
                    trackedCol.Insert(record);
                }
            }
        }

        public static void DeleteProcs(List<string> proc_names) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                // Delete record with proc_name fields that are in proc_names
                trackedCol.DeleteMany(record => proc_names.Contains(record.proc_name));
            }
        }

        // Updates the hours_used and date_opened field of every relevant proc
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

        // Updates an existing record with new values (called from EditRecordForm)
        public static void UpdateRecord(ProcRecord record) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                trackedCol.Update(record);
            }
        }

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

        // Get a List<ProcRecord> of every entry in the db
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

        public static ProcRecord GetProcRecord(string name) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");
                return trackedCol.FindOne(record => record.proc_name == name);
            }
        }

        public static ProcData GetProcData(string name) {
            ProcRecord record = GetProcRecord(name);

            return record.ToProcData();
        }

        // Convert db entries to List<ProcData> for display in TrackingList
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
