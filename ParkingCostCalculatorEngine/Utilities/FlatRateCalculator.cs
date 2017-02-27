using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.Utilities
{
    static class FlatRateCalculator
    {
        public static ReceiptModel Calculate(this IEnumerable<FlatRatePriceModel> rates, ParkingTimeModel parkingTime)
        {
            var match = rates
                .Where(r => r.IsMatch(parkingTime))
                .FirstOrDefault();

            return (match == null)
                ? null
                : new ReceiptModel()
                {
                    RateName = match.Name,
                    Details = parkingTime,
                    Price = match.Price,
                };
        }
    }
}
