using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Defines the information needed to calculate parking fees
    /// </summary>
    public class RatesModel
    {
        public List<StandardRatePriceModel> StandardRates { get; set; }
        public List<FlatRatePriceModel> FlatRates { get; set; }
        public decimal DefaultRatePerDay { get; set; }
    }
}
