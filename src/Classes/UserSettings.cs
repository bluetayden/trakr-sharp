namespace trakr_sharp {
    class UserSettings {
        #region Definitions
        private const int Close = 0;
        private const int Minimize = 1;
        #endregion

        public int CloseBehaviour { get; set; }
        public bool RunOnStartup { get; set; }
        public bool ShowUtilCols { get; set; }
    }
}
