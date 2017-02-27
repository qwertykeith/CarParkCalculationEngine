using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// A start and end time in hours (1-24)
    /// Minutes should be in decimal ie 6:30am would be 6.5
    /// </summary>
    public class TimeRange
    {
        public double StartHour { get; set; }
        public double EndHour { get; set; }
        public List<DayOfWeek> DaysOfWeek { get; set; }
    }

    public enum TimeRangeRule
    {
        NONE, SAMEDAY, SAMEORNEXTDAY
    }

    /// <summary>
    /// flat rate prices determined by specific entry and exit times 
    /// </summary>
    public class FlatRatePriceModel
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public TimeRange EntryTimeRange { get; set; }
        public TimeRange ExitTimeRange { get; set; }
        public TimeRangeRule ExitTimeRule { get; set; }
    }
}
