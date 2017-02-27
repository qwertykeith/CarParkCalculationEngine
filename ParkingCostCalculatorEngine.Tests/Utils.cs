using ParkingCostCalculatorEngine.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.Tests
{
    /// <summary>
    /// Utilities to help with testing
    /// </summary>
    static class Utils
    {
        public static ReceiptModel GetRates(DateTime entry, DateTime exit)
        {
            var rates = ParkingRatesProvider.GetRates();

            var times = new ParkingTimeModel()
            {
                Entry = entry,
                Exit = exit,
            };

            return rates.Calculate(times);
        }
    }
}
