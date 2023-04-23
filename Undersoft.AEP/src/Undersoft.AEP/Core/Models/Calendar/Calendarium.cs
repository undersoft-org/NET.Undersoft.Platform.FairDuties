using System.Globalization;
using System.Series;
using System.Uniques;

namespace Undersoft.AEP
{
    public enum CalendariumProperty
    {
        FourDigitYear,
        TwoDigitYer,
        Month,
        WeekOfYear,
        DayOfYear,
        DayOfMonth
    }

    public static class Calendarium
    {
        private static Calendar calendar = CultureInfo.InvariantCulture.Calendar;

        static Calendarium()
        {
            calendar.TwoDigitYearMax = 99;
        }

        public static IDeck<CalendariumItem> CreateByRange(int start, int end, CalendariumProperty element = CalendariumProperty.WeekOfYear)
        {
            var startTime = GetTimeByElement(start, element);
            var span = GetTimeByElement(end, element) - startTime;
            var deck = new Catalog<CalendariumItem>();
            for (int i = 0; i <= span.Days; i++)
                deck.Put(CreateItem(startTime.AddDays(i)));
            return deck;
        }

        public static IDeck<CalendariumItem> CreateByLength(int offset, int length, CalendariumProperty element = CalendariumProperty.WeekOfYear)
        {
            var startTime = GetTimeByElement(offset, element);
            var span = GetTimeByElement(offset + length, element) - startTime;
            var deck = new Catalog<CalendariumItem>();
            for (int i = 0; i <= span.Days; i++)
                deck.Put(CreateItem(startTime.AddDays(i)));
            return deck;
        }

        public static CalendariumItem CreateItem(DateTime time)
        {
            CalendariumItem item = new CalendariumItem();
            item.Era = calendar.GetEra(time);
            item.FourDigitYear = calendar.GetYear(time);
            item.TwoDigitYear = calendar.GetYear(time) - (calendar.TwoDigitYearMax - 99);
            item.WeekOfYear = calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            item.Month = calendar.GetMonth(time);
            item.DayOfYear = calendar.GetDayOfYear(time);
            item.DayOfMonth = calendar.GetMonth(time);
            item.DayOfWeek = calendar.GetDayOfWeek(time);
            item.Hour = calendar.GetHour(time);
            item.Minute = calendar.GetMinute(time);
            item.Second = calendar.GetSecond(time);
            item.Milliseconds = calendar.GetMilliseconds(time);

            return item;
        }

        public static DateTime GetTimeByElement(int number, CalendariumProperty element)
        {
            switch (element)
            {
                case CalendariumProperty.FourDigitYear:
                    return new DateTime(number, 1, 1);
                case CalendariumProperty.TwoDigitYer:
                    return new DateTime(number + 2000, 1, 1);
                case CalendariumProperty.Month:
                    return new DateTime(DateTime.Now.Year, number, 1);
                case CalendariumProperty.WeekOfYear:
                    return calendar.AddWeeks(new DateTime(DateTime.Now.Year, 1, 1), number);
                case CalendariumProperty.DayOfYear:
                    return calendar.AddDays(new DateTime(DateTime.Now.Year, 1, 1), number);
                case CalendariumProperty.DayOfMonth:
                    return calendar.AddDays(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), number);
                default:
                    return DateTime.MinValue;
            }
        }

    }

    public class CalendariumItem : UniqueObject
    {
        public int Era { get; set; }
        public int FourDigitYear { get; set; }
        public int TwoDigitYear { get; set; }
        public int WeekOfYear { get; set; }
        public int Month { get; set; }
        public int DayOfYear { get; set; }
        public int DayOfMonth { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public double Milliseconds { get; set; }

        public object Item { get; set; }
    }
}
