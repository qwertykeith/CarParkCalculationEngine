using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Provdes an extension over a list of rates in order to calculate costs for parking
    /// </summary>
    public static class CostCalculator
    {
        /// <summary>
        /// Calculates the price for parking based on the rates provided and the time the customer was parked.
        /// </summary>
        /// <param name="rates">Rates should be in preferred order, if there is overlap then the first match will be used.  Flat rates get precedence over standard rates.</param>
        /// <param name="parkingTime">The start and end times of the parking event</param>
        /// <returns></returns>
        public static Receipt Calculate(this IReadOnlyCollection<Rates> rates, ParkingTime parkingTime)
        {

        }
    }
}
