using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// One session of parking
    /// </summary>
    public class ParkingTime
    {
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }
    }
}
