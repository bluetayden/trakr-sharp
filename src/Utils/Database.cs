using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiteDB;

namespace trakr_sharp.Utils {
    class Database {
        private static readonly string _databasePath = "user_data/tracking.db";
        private static Random _RNG = new Random();

        private static LiteDatabase ConnectToDatabase() {
            return new LiteDatabase(_databasePath);
        }

        public static void Init() {
            // Create user_data folder if not exists
            System.IO.Directory.CreateDirectory("user_data");

            // Creates db file
            using (LiteDatabase db = ConnectToDatabase()) {
                // Create 'tracked' table if doesn't exist
                db.GetCollection<ProcRecord>("tracked");
            }
        }

        public static void InsertProcs(List<string> procNames) {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                foreach (string name in procNames) {
                    // Create instance ('record') of ProcRecord using 'name'
                    ProcRecord record = new ProcRecord {
                        proc_name = name,
                        program_name = name.Substring(0, name.Length - 4),
                        hours_used = 0,
                        opened_date = DateTime.UtcNow.ToString("o"),
                        added_date = DateTime.UtcNow.ToString("o")
                    };

                    // Insert record into db col
                    trackedCol.Insert(record);
                }
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

        public static void Test() {
            using (LiteDatabase db = ConnectToDatabase()) {
                // Get 'tracked' collection from db
                ILiteCollection<ProcRecord> trackedCol = db.GetCollection<ProcRecord>("tracked");

                // Create test record
                ProcRecord testRecord = new ProcRecord {
                    proc_name = "TestRecord.exe",
                    program_name = "TestRecord",
                    hours_used = _RNG.Next(0, 32767),
                    opened_date = DateTime.UtcNow.ToString("o"),
                    added_date = DateTime.UtcNow.ToString("o")
                };

                // Insert test record into db
                trackedCol.Insert(testRecord);

                // Query db for proc_name and hours_used
                var result =  trackedCol.Query()
                    .Select(record => new { record.proc_name, record.hours_used })
                    .ToList();

                // Print results
                foreach (object obj in result) {
                    Utils.SysCalls.Print(obj);
                }
            }
        }
    }
}
