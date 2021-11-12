namespace trakr_sharp {
    public class ProcRecord {
        public int Id { get; set; }
        public string proc_name { get; set; }
        public string program_name { get; set; }
        public long total_time { get; set; }
        public string date_opened { get; set; }
        public string date_added { get; set; }
        public string proc_path { get; set; }

        public ProcData ToProcData() {
            ProcData procData = new ProcData {
                Icon = Utils.SysCalls.GetIconFromCache(this.proc_name),
                Program_Name = this.program_name,
                Elapsed_Time = 0,
                Date_Opened = this.date_opened,
                Total_Time = this.total_time,
                Date_Added = this.date_added,

                Process_Name = this.proc_name,
                Process_Path = this.proc_path,
                Is_Running = false,
                Start_Time = -1,
            };

            return procData;
        }
    }
}
