
namespace Bioscoop.Domain
{
    public class Helpers
    {
        public static bool IsWeekDay(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }

            return false;
        }

        public static bool IsWeekendDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return false;
        }
    }
}
