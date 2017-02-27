using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine.Utilities
{
    static class StandardRateCalculator
    {
        public static ReceiptModel Calculate(this IEnumerable<StandardRatePriceModel> rates, ParkingTimeModel parkingTime)
        {
            // the order of the rules dictates which one should be chosen 
            // if there are multiple matches, ie take the first one
            var match = rates
                .OrderBy(r => r.UpToHours)
                .Where(r => r.IsMatch(parkingTime))
                .FirstOrDefault();

            return match == null
                ? null
                : new ReceiptModel()
                {
                    RateName = string.Format("Standard Rate Up To {0} Hour(s)", match.UpToHours),
                    Details = parkingTime,
                    Price = match.Price,
                };

        }
    }
}
