using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.StaticData
{
    /// <summary>
    /// Provides data defining rules for standard rates
    /// </summary>
    static class StandardRatesProvider
    {
        public static IEnumerable<StandardRatePriceModel> GetRates()
        {
            yield return new StandardRatePriceModel()
            {
                Price = 5m,
                UpToHours = 1,
            };

            yield return new StandardRatePriceModel()
            {
                Price = 10m,
                UpToHours = 2,
            };

            yield return new StandardRatePriceModel()
            {
                Price = 15m,
                UpToHours = 3,
            };


        }

    }
}
