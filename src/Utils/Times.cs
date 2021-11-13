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

        public static string GetCurrTimeStamp() {
            return DateTime.Now.ToString("h:mm:ss");
        }

        private static bool DatesAreInTheSameWeek(DateTime date1, DateTime date2) {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }

        public static string SecsToHMSString(long total_secs) {
            if (total_secs == 0) {
                return "0";
            }
            else if (total_secs < 60) {
                return String.Format("{0}s", total_secs);
            }
            else if (total_secs < 3600) {
                int mins = (int)Math.Floor((double)(total_secs / 60));
                int secs = (int)total_secs - (mins * 60);

                if (secs > 0) {
                    return String.Format("{0}m {1}s", mins, secs);
                }
                else {
                    return String.Format("{0}m", mins);
                }
            }
            else {
                int hours = (int)Math.Floor((double)total_secs / 3600);
                int mins = (int)(total_secs - (hours * 3600))/60;

                if (mins > 0) {
                    return String.Format("{0}h {1}m", hours, mins);
                }
                else {
                    return String.Format("{0}h", hours);
                }
            }
        }

        public static string SecsToHMString(long secs) {
            TimeSpan time = TimeSpan.FromSeconds(secs);

            return time.ToString(@"hh\:mm");
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

        public static DateTime LogicalDateStringToDateTime(string logical) {
            if (logical == "Today") {
                return DateTime.Now;
            }
            else if (logical.EndsWith("d")) {
                // Remove 'd' from string and parse int
                int days = int.Parse(logical.Substring(0, logical.Length - 1));

                return DateTime.Now.AddDays(-days);
            }
            else {
                return DateTime.Parse(logical);
            }
        }

        public static string ISOToShortDateString(string ISO) {
            return DateTime.Parse(ISO).ToString("dd/MM/yy");
        }
    }
}
