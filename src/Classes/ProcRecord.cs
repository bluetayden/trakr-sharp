namespace TrakrSharp {
    /// <summary>
    /// Represents a document for a tracked process that is stored in the Database
    /// </summary>
    public class ProcRecord {
        #region Fields
        public int Id { get; set; }
        public string proc_name { get; set; }
        public string program_name { get; set; }
        public long total_time { get; set; }
        public string date_opened { get; set; }
        public string date_added { get; set; }
        public string proc_path { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Cast document for runtime use
        /// </summary>
        public ProcData ToProcData() {
            ProcData procData = new ProcData {
                Icon = Utils.SysCalls.GetIconFromCache(this.proc_name),
                ProgramName = this.program_name,
                ElapsedTime = 0,
                DateOpened = this.date_opened,
                TotalTime = this.total_time,
                DateAdded = this.date_added,

                ProcessName = this.proc_name,
                ProcessPath = this.proc_path,
                IsRunning = false,
                StartTime = -1,
            };

            return procData;
        }
        #endregion
    }
}
