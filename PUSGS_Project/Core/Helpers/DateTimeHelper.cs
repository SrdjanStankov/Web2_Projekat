using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public static class DateTimeHelper
    {
        public static bool AreSameDay(DateTime firstDate, DateTime secondDate)
        {
            return firstDate.Year == secondDate.Year
                && firstDate.Month == secondDate.Month
                && firstDate.Day == secondDate.Day;
        }

        public static bool IsLessInHours(DateTime date, DateTime comparedTo, double minAllowedHourDiff = 3)
        {
            TimeSpan diff = comparedTo - date;
            return diff.TotalHours > minAllowedHourDiff;
        }

        public static bool IsLessInDays(DateTime date, DateTime comparedTo, double minAllowedDayDiff = 2)
        {
            TimeSpan diff = comparedTo - date;
            return diff.TotalDays > minAllowedDayDiff;
        }
    }
}