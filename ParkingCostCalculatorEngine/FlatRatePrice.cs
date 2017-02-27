using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// A start and end time in hours (1-24)
    /// </summary>
    public class TimeRange
    {
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }

    public enum TimeRangeRule
    {
        TODAY, MAXONEDAY
    }

    /// <summary>
    /// flat rate prices determined by specific entry and exit times 
    /// </summary>
    public class FlatRatePrice
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public TimeRange EntryTimeRange { get; set; }
        public TimeRange ExitTimeRange { get; set; }
        public TimeRangeRule ExitTimeRule { get; set; }
    }
}
