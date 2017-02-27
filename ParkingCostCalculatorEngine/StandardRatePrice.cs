using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Standard rate prices charged by the hour
    /// </summary>
    public class StandardRatePrice
    {
        public decimal Price { get; set; }
        public double MinHours { get; set; }
        public double MaxHours { get; set; }

    }
}
