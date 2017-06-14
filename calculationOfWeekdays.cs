/*
 * function: to count the weekdays between 2 dates;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculationOfWeekdays
{
    class Program
    {
        public static int Weekdays(DateTime dtmStart, DateTime dtmEnd)
        {
            // This function includes the start and end date in the count if they fall on a weekday
            int dowStart = ((int)dtmStart.DayOfWeek == 0 ? 7 : (int)dtmStart.DayOfWeek);
            int dowEnd = ((int)dtmEnd.DayOfWeek == 0 ? 7 : (int)dtmEnd.DayOfWeek);
            TimeSpan tSpan = dtmEnd - dtmStart;
            if (dowStart <= dowEnd)
            {
                return (((tSpan.Days / 7) * 5) + Math.Max((Math.Min((dowEnd + 1), 6) - dowStart), 0));
            }
            return (((tSpan.Days / 7) * 5) + Math.Min((dowEnd + 6) - Math.Min(dowStart, 6), 5));
        }

        public static int Weekends(DateTime dtmStart, DateTime dtmEnd)
        {
            int dowStart = ((int)dtmStart.DayOfWeek == 0 ? 7 : (int)dtmStart.DayOfWeek);
            int dowEnd = ((int)dtmEnd.DayOfWeek == 0 ? 7 : (int)dtmEnd.DayOfWeek);
            TimeSpan tSpan = dtmEnd - dtmStart;
            Console.WriteLine("the timespan is " + (tSpan.Days+1));
            int nWeekdays = Weekdays(dtmStart, dtmEnd);
            return tSpan.Days - nWeekdays + 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("startYear: ");
            int yearStart = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("startMonth: ");
            int monStart = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("StartDay: ");
            int dayStart = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=========");
            Console.WriteLine("EndYear: ");
            int yearEnd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("EndMonth: ");
            int monEnd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("EndDay: ");
            int dayEnd = Convert.ToInt32(Console.ReadLine());

            int nWeekdays = Weekdays(new DateTime(yearStart, monStart, dayStart), new DateTime(yearEnd, monEnd, dayEnd));
            int nWeekends = Weekends(new DateTime(yearStart, monStart, dayStart), new DateTime(yearEnd, monEnd, dayEnd));

            Console.WriteLine("the no of weekdays between {0}-{1}-{2} and {3}-{4}-{5} is {6}",yearStart,monStart,dayStart,yearEnd,monEnd,dayEnd,nWeekdays);
            Console.WriteLine("the no of weekends between {0}-{1}-{2} and {3}-{4}-{5} is {6}", yearStart, monStart, dayStart, yearEnd, monEnd, dayEnd,nWeekends);

            int allowancePerWeekday = 60;
            int allowancePerWeekend = 90;
            int allowanceTotal = allowancePerWeekday * nWeekdays + allowancePerWeekend * nWeekends;

            Console.WriteLine("Total allowance is ￥" + allowanceTotal);

            Console.WriteLine("=========");
            Console.WriteLine("days in hotel: ");
            int daysInHotel = Convert.ToInt32(Console.ReadLine());
            int feePerDay = 135;
            int feePerDayForInvoice = 180;
            int taxPoint = 3;//%
            double taxTotal = (feePerDayForInvoice - feePerDay) * taxPoint / 100 * daysInHotel;
            double feeTotalReimbursment = feePerDayForInvoice * daysInHotel;
            double incomeOfHotel = .5 * (feeTotalReimbursment - taxTotal);
            Console.WriteLine("The total fee on invoice for hotel is ￥" + feeTotalReimbursment);
            Console.WriteLine("The tax is ￥" + taxTotal);
            Console.WriteLine("HOW MUCH LEFT? ￥" + (feeTotalReimbursment - taxTotal));
            Console.WriteLine("HOW MUCH FOR ONE PERSON? ￥" + incomeOfHotel);
            Console.WriteLine("=========");
            double incomeTotal = incomeOfHotel + allowanceTotal;
            Console.WriteLine("total income this time: ￥" + incomeTotal);
            


            Console.ReadKey();

        }
    }
}
