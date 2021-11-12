namespace trakr_sharp {
    class UserSettings {
        public enum CloseBehaviour {
            Close = 0,
            Minimize = 1
        }

        public CloseBehaviour OnClose { get; set; }
        public bool RunOnStartup { get; set; }
        public bool ShowUtilCols { get; set; }
    }
}
