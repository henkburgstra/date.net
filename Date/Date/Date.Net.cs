using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date.Net
{
    public struct Age
    {
        public int Years;
        public int Months;
    }

    public static class DateExtensions
    {

        public static DateTime AddWeeks(this DateTime date, int weeks)
        {
            return date.AddDays(7 * weeks);
        }
        public static DateTime AddQuarters(this DateTime date, int quarters)
        {
            return date.AddMonths(3 * quarters);
        }
        public static Age Age(this DateTime date, DateTime referenceDate = default(DateTime))
        {
            if (referenceDate.Year == 1)
            {
                referenceDate = DateTime.Today;
            }
            var months = (referenceDate.Year - date.Year) * 12 + (referenceDate.Month - date.Month);
            if (referenceDate.Day < date.Day)
            {
                months--;
            }
            var age = new Age();
            age.Years = months / 12;
            age.Months = months % 12;
            return age;
        }

    }
}
