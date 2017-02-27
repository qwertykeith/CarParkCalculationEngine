using ParkingCostCalculatorEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Provides an extension over a list of rates definitions in order to calculate costs for parking
    /// </summary>
    public static class ParkingCostCalculator
    {
        /// <summary>
        /// Calculates the price for parking based on the rates provided and the time the customer was parked.
        /// The customer's parking times will be matched against the rules for rates and the best one will be used to calculate a price
        /// </summary>
        /// <param name="rates">Rates should be in preferred order, if there is overlap then the first match will be used.  
        /// Flat rates get precedence over standard rates.</param>
        /// <param name="parkingTime">The start and end times of the parking event</param>
        /// <returns></returns>
        public static ReceiptModel Calculate(this RatesModel rates, ParkingTimeModel parkingTime)
        {
            if (parkingTime.Entry > parkingTime.Exit) throw new Exception("Exit time cannot be before entry time!");
            // TODO any other validation here

            return
                // first check for a matching flat rate
                rates.FlatRates.Calculate(parkingTime)
                // ok, now do we match a standard rate?
                ?? rates.StandardRates.Calculate(parkingTime)
                // no matches to any rates, fall back to the day rate
                ?? DayRateCalculator.Calculate(rates.DefaultRatePerDay, parkingTime);

        }
    }
}
