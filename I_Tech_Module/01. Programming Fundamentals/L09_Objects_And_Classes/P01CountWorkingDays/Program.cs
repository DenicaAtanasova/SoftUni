using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDateText = Console.ReadLine();
            string endDateText = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(startDateText, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endDateText, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] holidays = new DateTime []
            {
                new DateTime(4, 01, 01),
                new DateTime(4, 03, 03),
                new DateTime(4, 05, 01),
                new DateTime(4, 05, 06),
                new DateTime(4, 05, 24),
                new DateTime(4, 09, 06),
                new DateTime(4, 09, 22),
                new DateTime(4, 11, 01),
                new DateTime(4, 12, 24),
                new DateTime(4, 12, 25),
                new DateTime(4, 12, 26),
            };

            int workingDays = 0;
            for (DateTime day = startDate; day <= endDate; day = day.AddDays(1.0))
            {
                DateTime current = new DateTime(4, day.Month, day.Day);
                if ((day.DayOfWeek != DayOfWeek.Saturday) && (day.DayOfWeek != DayOfWeek.Sunday) && !(holidays.Contains(current)))
                {
                    workingDays++;
                }
            }
            Console.WriteLine(workingDays);
        }
    }
}
