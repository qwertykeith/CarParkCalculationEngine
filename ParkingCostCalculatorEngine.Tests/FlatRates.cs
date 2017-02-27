using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCostCalculatorEngine.StaticData;

namespace ParkingCostCalculatorEngine.Tests
{
    [TestClass]
    public class FlatRates
    {

        [TestMethod]
        public void EarlyBirdWeekday()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 2, 27, 7, 22, 0), // monday 7:22am 
                new DateTime(2017, 2, 27, 21, 55, 0) // same monday 9:55pm
            );

            Assert.AreEqual(result.Price, 13m);
        }

        [TestMethod]
        public void EarlyBirdWeekend()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 3, 4, 8, 30, 0), // saturday 8:30am 
                new DateTime(2017, 3, 4, 21, 55, 0) // same sat 9:55pm
            );

            Assert.AreEqual(result.Price, 13m);
        }

        [TestMethod]
        public void NightRate()
        {
            var result = Utils.GetRates(
                            new DateTime(2017, 2, 27, 18, 22, 0), // monday 6:22pm 
                            new DateTime(2017, 2, 28, 4, 55, 0) // next day 4:55am
                        );

            Assert.AreEqual(result.Price, 6.5m);
        }

        [TestMethod]
        public void WeekendRateTwoDays()
        {
            var result = Utils.GetRates(
                            new DateTime(2017, 3, 4, 1, 22, 0), // saturday 1:22am 
                            new DateTime(2017, 3, 5, 23, 55, 0) // next sun 11:55pm
                        );

            Assert.AreEqual(result.Price, 10m);
        }

        [TestMethod]
        public void WeekendRateSaturday()
        {
            // short stay on a saturday
            var result = Utils.GetRates(
                            new DateTime(2017, 3, 4, 1, 22, 0), // saturday 1:22am 
                            new DateTime(2017, 3, 4, 1, 55, 0) // saturday 1:55am
                        );

            Assert.AreEqual(result.Price, 10m);
        }


    }
}
