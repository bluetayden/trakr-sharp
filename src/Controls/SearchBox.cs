using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trakr_sharp.Controls {
    public partial class SearchBox : UserControl {
        #region Init
        public delegate void OnValidQueryDelegate(SearchBox sender, string query); // Create delegator for public query event
        public event OnValidQueryDelegate OnValidQuery; // Create instance of that event from delegator
        private readonly string _placeholderText = "Search...";

        public SearchBox() {
            InitializeComponent();
            this.queryBox.SelectionStart = 0;
        }
        #endregion

        #region PublicEventRaisers
        /// <summary>
        /// Raises a public event if the text of queryBox is changed and is not _placeholderText 
        /// </summary>
        private void queryBox_TextChanged(object sender, EventArgs e) {
            if (this.queryBox.Text != _placeholderText) {
                OnValidQuery?.Invoke(this, this.queryBox.Text);
            }
        }
        #endregion

        #region LocalEventHandlers
        private void queryBox_OnFocus(object sender, EventArgs e) {
            removePlaceholder();
        }

        private void queryBox_OnLeave(object sender, EventArgs e) {
            setPlaceholder();
        }
        #endregion

        #region Methods
        // Member functions
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
