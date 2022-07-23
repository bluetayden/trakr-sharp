namespace TrakrSharp {
    public struct UserSettings {
        public enum CloseBehaviour { Close = 0, Minimize = 1 }

        public CloseBehaviour OnClose { get; set; }
        public bool RunOnStartup { get; set; }
        public bool EnableScreenshots { get; set; }
        public bool ShowUtilCols { get; set; }

        public UserSettings(UserSettings.CloseBehaviour onClose, bool runOnStartup, 
            bool enableScreenshots, bool showUtilCols) {
            OnClose = onClose;
            RunOnStartup = runOnStartup;
            EnableScreenshots = enableScreenshots;
            ShowUtilCols = showUtilCols;
        }

        public static UserSettings Default {
            get => new UserSettings(UserSettings.CloseBehaviour.Close, false, false, false);
        }
    }
}
