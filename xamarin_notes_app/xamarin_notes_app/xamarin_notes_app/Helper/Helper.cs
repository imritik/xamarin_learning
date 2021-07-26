using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Helper
{
    public static class Helper
    {
        public static string GetFormattedTimeString(DateTime time)
        {
            TimeSpan timeSpan = DateTime.Now - time;
            if (timeSpan.Days > 365)
            {
                int years = (timeSpan.Days / 365);
                return String.Format("{0} {1} ago", years, years == 1 ? "year" : "years");
            }
            if (timeSpan.Days > 30)
            {
                int months = (timeSpan.Days / 30);
                return String.Format("{0} {1} ago", months, months == 1 ? "month" : "months");
            }
            if (timeSpan.Days > 0)
            {
                return String.Format("{0} {1} ago",
                timeSpan.Days, timeSpan.Days == 1 ? "day" : "days");
            }
            if (timeSpan.Hours > 0)
            {
                return String.Format("{0} {1} ago",
                timeSpan.Hours, timeSpan.Hours == 1 ? "hour" : "hours");
            }
            if (timeSpan.Minutes > 0)
            {
                return String.Format("{0} {1} ago",
                timeSpan.Minutes, timeSpan.Minutes == 1 ? "minute" : "minutes");
            }
            if (timeSpan.Seconds <= 59)
            {
                return "moments ago";
            }
            return string.Empty;
        }
    }
}
