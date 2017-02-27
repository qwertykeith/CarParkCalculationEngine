using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParkingCostCalculatorEngine.Tests
{
    [TestClass]
    public class WierdEdgeCases
    {
        [TestMethod]
        public void ParkOnWeekendFor1Week()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 2, 4, 10, 22, 0), // saturday morning
                new DateTime(2017, 2, 11, 23, 55, 0) // next saturday (8 calendar days)
            );

            Assert.AreEqual(result.Price, 160m);
        }

        [TestMethod]
        public void ParkOnWeekendForAFewDays()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 2, 4, 10, 22, 0), // saturday morning
                new DateTime(2017, 2, 8, 9, 55, 0) // next wed (5 calendar days)
            );

            Assert.AreEqual(result.Price, 100m);
        }

        [TestMethod]
        public void ParkEarlyForAFewDays()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 2, 1, 6, 22, 0), // wed morning
                new DateTime(2017, 2, 5, 9, 55, 0) // next sun (5 calendar days)
            );

            Assert.AreEqual(result.Price, 100m);
        }

        [TestMethod]
        public void ParkNightRateOverWeekend()
        {
            // If a patron enters the carpark before midnight on Friday and if they qualify 
            // for Night rate on a Saturday morning, then the program should charge the night 
            // rate instead of weekend rate.  

            var result = Utils.GetRates(
                new DateTime(2017, 2, 10, 23, 22, 0), // friday night before mimdnight
                new DateTime(2017, 2, 11, 2, 55, 0) // sat monring next day
            );

            Assert.AreEqual(result.Price, 6.5m);
        }


    }

}
