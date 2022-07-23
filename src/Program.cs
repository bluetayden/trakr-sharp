using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrakrSharp {
    static class Program {
        // Unique GUID to differentiate this app process from others
        private static readonly string appGUID = "ToolAssistedBreakcore";

        [STAThread]
        static void Main() {
            // Create a disposable mutex lock using the GUID
            using (Mutex mutex = new Mutex(false, "Global\\" + appGUID)) {
                // If the lock is already acquired (the process is already running) stop execution 
                if (!mutex.WaitOne(0, false)) {
                    return;
                }
                // Otherwise run the program as normal
                else {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
