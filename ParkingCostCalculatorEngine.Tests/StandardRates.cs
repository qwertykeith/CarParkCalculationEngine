using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParkingCostCalculatorEngine.Tests
{
    [TestClass]
    public class StandardRates
    {
        [TestMethod]
        public void StandardLessThan1Hour()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 2, 27, 10, 22, 0), // monday 10:22am 
                new DateTime(2017, 2, 27, 10, 55, 0) // monday 10:55pm
            );

            Assert.AreEqual(result.Price, 5m);
        }

        [TestMethod]
        public void StandardMoreThan1LessThan2Hours()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 3, 1, 15, 44, 0), // wed 3:44pm 
                new DateTime(2017, 3, 1, 16, 55, 0) // wed 4:55pm
            );

            Assert.AreEqual(result.Price, 10m);
        }

        [TestMethod]
        public void StandardMoreThan2LessThan3Hours()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 3, 1, 15, 44, 0), // wed 3:44pm 
                new DateTime(2017, 3, 1, 17, 55, 0) // wed 5:55pm
            );

            Assert.AreEqual(result.Price, 15m);
        }

        [TestMethod]
        public void StandardMoreThan3HoursSameDay()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 3, 1, 15, 44, 0), // wed 3:44pm 
                new DateTime(2017, 3, 1, 21, 55, 0) // wed 9:55pm
            );

            Assert.AreEqual(result.Price, 20m);
        }

        [TestMethod]
        public void Standard10CalendarDays()
        {
            var result = Utils.GetRates(
                new DateTime(2017, 3, 1, 15, 44, 0), // wed 3:44pm 
                new DateTime(2017, 3, 10, 21, 55, 0) // 10 days later 
            );

            Assert.AreEqual(result.Price, 200m);
        }

    }
}
