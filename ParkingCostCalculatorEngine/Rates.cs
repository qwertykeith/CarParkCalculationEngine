using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    public class Rates
    {
        public List<StandardRatePrice> StandardRates { get; set; }
        public List<FlatRatePrice> FlatRates { get; set; }
    }
}
