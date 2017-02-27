using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.StaticData
{
    /// <summary>
    /// Provides data defining rules for flat rates
    /// </summary>
    static class FlatRatesProvider
    {
        public static IEnumerable<FlatRatePriceModel> GetRates()
        {
            var everyDay = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday }.ToList();
            var weekdays = everyDay.Except(weekend).ToList();

            // early bird price
            yield return new FlatRatePriceModel()
            {
                Name = "Early Bird",
                Price = 13m,
                EntryTimeRange = new TimeRange()
                {
                    StartHour = 6,
                    EndHour = 9,
                    DaysOfWeek = everyDay
                },
                ExitTimeRange = new TimeRange()
                {
                    StartHour = 3.5,
                    EndHour = 23.5,
                    DaysOfWeek = everyDay,
                },
                ExitTimeRule = TimeRangeRule.SAMEDAY
            };

            // night rate price
            yield return new FlatRatePriceModel()
            {
                Name = "Night Rate",
                Price = 6.5m,
                EntryTimeRange = new TimeRange()
                {
                    StartHour = 18,
                    EndHour = 23.999999,
                    DaysOfWeek = weekdays,
                },
                ExitTimeRange = new TimeRange()
                {
                    StartHour = 18,
                    EndHour = 6,
                    DaysOfWeek = everyDay,
                },
                ExitTimeRule = TimeRangeRule.SAMEORNEXTDAY
            };

            // weekend rate price
            yield return new FlatRatePriceModel()
            {
                Name = "Weekend Rate",
                Price = 10m,
                EntryTimeRange = new TimeRange()
                {
                    StartHour = 0,
                    EndHour = 24,
                    DaysOfWeek = weekend,
                },
                ExitTimeRange = new TimeRange()
                {
                    StartHour = 0,
                    EndHour = 24,
                    DaysOfWeek = weekend,
                },
                ExitTimeRule = TimeRangeRule.SAMEORNEXTDAY
            };

        }
    }
}
