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
        public static Age Age(this DateTime date)
        {
            var age = new Age();
            return age;
        }

    }
}
