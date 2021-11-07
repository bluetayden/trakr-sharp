using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trakr_sharp.Utils {
    class Strings {
        public static string SecsToElapsedString(Int32 secs) {
            if (secs < 60) {
                return String.Format("{0}s", secs);
            }
            else if (secs < 3600) {
                return String.Format("{0}m", Math.Ceiling((double)secs / 60));
            }
            else {
                return String.Format("{0}h", Math.Ceiling((double)secs / 3600));
            }

        }

        public static string SecsToHoursString(Int32 secs) {
            return ((float)secs / 3600).ToString("0.00");
        }
    }
}
