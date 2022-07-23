using System;
using System.Windows.Forms;

namespace TrakrSharp.Controls {
    public partial class SearchBox : UserControl {
        private readonly string _placeholderText = "Search...";
        public delegate void OnValidQueryDelegate(SearchBox sender, string query);
        public event OnValidQueryDelegate OnValidQuery;

        #region Init
        public SearchBox() {
            InitializeComponent();
            this.queryBox.SelectionStart = 0;
        }
        #endregion

        #region Public Event Raisers
        /// <summary>
        /// Raises a public event if the text of queryBox is changed and is not _placeholderText 
        /// </summary>
        private void queryBox_TextChanged(object sender, EventArgs e) {
            if (this.queryBox.Text != _placeholderText) {
                OnValidQuery?.Invoke(this, this.queryBox.Text.ToLower());
            }
        }
        #endregion

        #region Local Event Handlers
        private void queryBox_OnFocus(object sender, EventArgs e) {
            removePlaceholder();
        }

        private void queryBox_OnLeave(object sender, EventArgs e) {
            setPlaceholder();
        }
        #endregion

        #region Methods
        private void removePlaceholder() {
            if (this.queryBox.Text == _placeholderText) {
                this.queryBox.Text = "";
            }
        }

        private void setPlaceholder() {
            if (this.queryBox.Text == "") {
                this.queryBox.Text = _placeholderText;
            }
        }

        public void clearQueryBox() {
            this.queryBox.Text = _placeholderText;
        }
        #endregion
    }
}
