using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.Utilities
{
    static class DayRateCalculator
    {
        public static ReceiptModel Calculate(decimal dayRate, ParkingTimeModel parkingTime)
        {
            var calenderDays = parkingTime.GetCalendarDaysParked();
            var price = dayRate * (decimal)calenderDays;

            return new ReceiptModel()
            {
                RateName = string.Format("Day Rate - {0} Calendar Day(s)", calenderDays),
                Details = parkingTime,
                Price = price,
            };
        }

    }
}
