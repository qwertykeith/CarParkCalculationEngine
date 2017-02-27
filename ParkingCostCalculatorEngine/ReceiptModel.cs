using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Receipt information containing resultant fees and other data calculated after a patron's parking experience
    /// </summary>
    public class ReceiptModel
    {
        public string RateName { get; set; }
        public decimal Price { get; set; }
        public ParkingTimeModel Details { get; set; }
    }
}
