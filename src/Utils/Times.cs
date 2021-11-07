using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trakr_sharp.Utils {
    class Times {
        public static long GetUTCNow() {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        private static bool DatesAreInTheSameWeek(DateTime date1, DateTime date2) {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }

        public static string SecsToElapsedString(long secs) {
            if (secs == 0) {
                return "0";
            }
            else if (secs < 60) {
                return String.Format("{0}s", secs);
            }
            else if (secs < 3600) {
                return String.Format("{0}m", Math.Ceiling((double)secs / 60));
            }
            else {
                int hours = (int)Math.Floor((double)secs / 3600);
                int mins = (int)(secs - (hours * 3600))/60;

                return String.Format("{0}h {1}m", hours, mins);
            }
        }

        public static string ISOToLogicalDateString(string ISO) {
            DateTime ISO_date = DateTime.Parse(ISO);
            DateTime curr_date = DateTime.Now;

            if (ISO_date.Day == curr_date.Day) {
                return "Today";
            }
            else if (DatesAreInTheSameWeek(ISO_date, curr_date)) {
                // {num}d
                return String.Format("{0}d", (int)Math.Ceiling((curr_date - ISO_date).TotalDays));
            }
            else {
                // dd/MM/yy
                return ISO_date.ToShortDateString();
            }
        }

        public static string ISOToShortDateString(string ISO) {
            return DateTime.Parse(ISO).ToShortDateString();
        }
    }
}
