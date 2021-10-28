using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace trakr_sharp.Utils {
    class Database {
        private static readonly string _databasePath = "user_data/tracking.db";
        private static readonly string _connectionString = "Data Source=" + _databasePath + ";Version=3;";

        private static SQLiteConnection ConnectToDatabase() {
            return new SQLiteConnection(_connectionString);
        }

        public static void Init() {
            // Create user_data folder if not exists
            System.IO.Directory.CreateDirectory("user_data");

            // Create tracked_programs.db if not exists
            if (!System.IO.File.Exists("user_data/tracking.db")) {
                SQLiteConnection.CreateFile(_databasePath);
            }

            using (SQLiteConnection db = ConnectToDatabase()) {
                // Open connection to db
                db.Open();

                // Init db tables
                SQLiteCommand table_init = new SQLiteCommand("CREATE TABLE IF NOT EXISTS programs " +
                    "(program_name, process_name, opened_date, hours_used, added_date)", db);

                table_init.ExecuteNonQuery();

                // Close connection
                db.Close();
            }
        }

        public static void InsertPrograms(List<string> procs) {
            using (SQLiteConnection db = ConnectToDatabase()) {
                db.Open();

                SQLiteCommand insert_cmd = new SQLiteCommand("INSERT INTO programs (program_name, process_name, " +
                    "hours_used, added_date) VALUES(@name, @proc, @hours, @date)", db);
                SQLiteCommand exists_cmd = new SQLiteCommand("SELECT COUNT(*) FROM programs WHERE process_name = " +
                    "@proc", db);

                foreach (string proc in procs) {
                    // Check if proc already in db
                    exists_cmd.Parameters.AddWithValue("@proc", proc);
                    int proc_exists = Convert.ToInt32(exists_cmd.ExecuteScalar());

                    // If the proc doesn't exist add it
                    if (proc_exists == 0) {
                        insert_cmd.Parameters.AddWithValue("@name", proc.Substring(0, proc.Length - 4));
                        insert_cmd.Parameters.AddWithValue("@proc", proc);
                        insert_cmd.Parameters.AddWithValue("@hours", 0);
                        insert_cmd.Parameters.AddWithValue("@date", DateTime.UtcNow.ToString("o"));

                        insert_cmd.ExecuteNonQuery();
                    }
                }

                db.Close();
            }
        }

        public static List<string> GetProcessNameList() {
            List<string> procList = new List<string>();

            using (SQLiteConnection db = ConnectToDatabase()) {
                db.Open();

                // Create command
                SQLiteCommand get_cmd = new SQLiteCommand("SELECT process_name FROM programs", db);

                // Get db_reader by calling command
                using (SQLiteDataReader db_reader = get_cmd.ExecuteReader()) {
                    // While reader not empty
                    while (db_reader.Read()) {
                        // Save values from process_name column to procList
                        procList.Add(Convert.ToString(db_reader["process_name"]));
                    }
                }

                db.Close();
            }

            return procList;
        }

        public static void Test() {
            using (SQLiteConnection db = ConnectToDatabase()) {
                db.Open();

                SQLiteCommand insert_test = new SQLiteCommand("INSERT INTO programs (program_name, process_name) " +
                    "values('Test Name', 'Test Process')", db);

                insert_test.ExecuteNonQuery();

                db.Close();
            }
        }
    }
}
