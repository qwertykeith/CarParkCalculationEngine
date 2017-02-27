using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.StaticData
{
    /// <summary>
    /// Provides all the data needed calculating rates
    /// </summary>
    public static class ParkingRatesProvider
    {
        public static RatesModel GetRates()
        {
            return new RatesModel()
            {
                DefaultRatePerDay = 20m,
                FlatRates = FlatRatesProvider.GetRates().ToList(),
                StandardRates = StandardRatesProvider.GetRates().ToList(),
            };
        }
    }
}
