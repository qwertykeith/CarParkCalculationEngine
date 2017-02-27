using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Standard rate prices charged by the hour
    /// minutes should be in decimal, eg 1:30 as 1.5 hours
    /// </summary>
    public class StandardRatePriceModel
    {
        public decimal Price { get; set; }
        public double UpToHours { get; set; }

    }
}
