using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date.Net
{

    public enum Interval
    {
        INVALID, DAILY, WEEKLY, TWO_WEEKLY, THREE_WEEKLY, FOUR_WEEKLY, MONTHLY,
        FIRST_OF_MONTH, SECOND_OF_MONTH, THIRD_OF_MONTH, FOURTH_OF_MONTH, QUARTERLY, YEARLY
    }

    public class DateRepeater
    {
        public Interval Interval;
        public DateTime Begin;
        public DateTime End;

        public DateRepeater(Interval interval, DateTime begin=default(DateTime), DateTime end=default(DateTime))
        {
            this.Interval = interval;

            if (begin.Year == 1)
            {
                Begin = DateTime.Today;
            }
            else
            {
                Begin = begin;
            }
            End = end;
        }

        public IEnumerable<DateTime> Repeat()
        {
            DateTime date = new DateTime(Begin.Year, Begin.Month, Begin.Day);
            DateTime end = new DateTime(End.Year, End.Month, End.Day);
            if (end.Year == 1)
            {
                end = date.AddYears(10);
            }
            while (date <= end)
            {
                yield return date;
                switch (this.Interval)
                {
                    case Interval.WEEKLY:
                        date = date.AddWeeks(1);
                        break;
                    case Interval.TWO_WEEKLY:
                        date = date.AddWeeks(2);
                        break;
                    case Interval.THREE_WEEKLY:
                        date = date.AddWeeks(3);
                        break;
                    case Interval.FOUR_WEEKLY:
                        date = date.AddWeeks(4);
                        break;
                    case Interval.DAILY:
                    default:
                        date = date.AddDays(1);
                        break;
                }
            }
        }

        public bool Contains(DateTime date)
        {

            switch (this.Interval)
            {
                case Interval.DAILY:
                    return DayIntervalContains(date);
                case Interval.WEEKLY:
                    return WeekIntervalContains(date, 1);
                case Interval.TWO_WEEKLY:
                    return WeekIntervalContains(date, 2);
                case Interval.THREE_WEEKLY:
                    return WeekIntervalContains(date, 3);
                case Interval.FOUR_WEEKLY:
                    return WeekIntervalContains(date, 4);
            }

            return false;
        }

        public bool DayIntervalContains(DateTime date)
        {
            return date >= Begin && (End.Year == 1 || date <= End);
        }

        public bool WeekIntervalContains(DateTime date, int weeks)
        {
            if (End.Year != 1 && End == date)
            {
                return true;
            }
            if (Begin > date || End.Year != 1 && End < date)
            {
                return false;
            }
            var compare = new DateTime(date.Year, date.Month, date.Day);
            while (compare <= date)
            {
                if (compare == date)
                {
                    return true;
                }
                compare = compare.AddWeeks(weeks);
            }
            return false;
        }
    }

    public struct Age
    {
        public int Years;
        public int Months;
    }

    public static class DateExtensions
    {
        public static string Description(this Interval interval)
        {
            switch (interval)
            {
                case Interval.DAILY:
                    return "every day";
                case Interval.WEEKLY:
                    return "every week";
                case Interval.TWO_WEEKLY:
                    return "every two weeks";
                case Interval.THREE_WEEKLY:
                    return "every three weeks";
                case Interval.FOUR_WEEKLY:
                    return "every four weeks";
                case Interval.MONTHLY:
                    return "every month";
                case Interval.FIRST_OF_MONTH:;
                    return "every first mon, tue, ... of the month";
                case Interval.SECOND_OF_MONTH:
                    return "every second mon, tue, ... of the month";
                case Interval.THIRD_OF_MONTH:
                    return "every third mon, tue, ... of the month";
                case Interval.FOURTH_OF_MONTH:
                    return "every fourth mon, tue, ... of the month";
                case Interval.QUARTERLY:
                    return "every quarter";
                case Interval.YEARLY:
                    return "every year";
                case Interval.INVALID:
                default:
                    return "Invalid interval";
            }
        }

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
