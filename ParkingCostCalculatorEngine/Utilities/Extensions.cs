using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// handy internal extensions for calculating parking prices
    /// </summary>
    static class Extensions
    {
        public static bool IsMatch(this StandardRatePriceModel rate, ParkingTimeModel parkingTimes)
        {
            return parkingTimes.GetHoursParked() <= rate.UpToHours;
        }

        public static bool IsMatch(this FlatRatePriceModel rate, ParkingTimeModel parkingTimes)
        {
            var entryMatch = rate.EntryTimeRange.MatchesHourRange(parkingTimes.Entry);
            var exitMatch = rate.ExitTimeRange.MatchesHourRange(parkingTimes.Exit);
            var exitRuleMatch = rate.PassesExitTimeRule(parkingTimes);

            return entryMatch && exitMatch && exitRuleMatch;
        }

        public static bool MatchesHourRange(this TimeRange timeRange, DateTime time)
        {
            var startTime = time.Date.AddHours(timeRange.StartHour);
            var endTime = time.Date.AddHours(timeRange.EndHour);
            var correctDay = timeRange.DaysOfWeek.Contains(time.DayOfWeek);

            if (!correctDay) return false;

            // if the start time is bigger than the end time.. it means this spans days
            // so reverse the logic
            return startTime > endTime
                ? time < startTime || time >= endTime
                : time >= startTime && time < endTime;
        }

        public static double GetCalendarDaysParked(this ParkingTimeModel parkingTimes)
        {
            return (parkingTimes.Exit.Date - parkingTimes.Entry.Date).TotalDays + 1;
        }

        public static double GetHoursParked(this ParkingTimeModel parkingTimes)
        {
            return (parkingTimes.Exit - parkingTimes.Entry).TotalHours;
        }

        public static bool PassesExitTimeRule(this FlatRatePriceModel rate, ParkingTimeModel parkingTimes)
        {
            switch (rate.ExitTimeRule)
            {
                case TimeRangeRule.SAMEDAY:
                    return parkingTimes.Entry.Date == parkingTimes.Exit.Date;
                case TimeRangeRule.SAMEORNEXTDAY:
                    return parkingTimes.Entry.Date == parkingTimes.Exit.Date || parkingTimes.Entry.AddDays(1).Date == parkingTimes.Exit.Date;
                default:
                    return true;
            }
        }

    }
}
