using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCostCalculatorEngine
{
    /// <summary>
    /// Fees and information for parking
    /// </summary>
    public class Receipt
    {
        public string RateName { get; set; }
        public decimal Price { get; set; }
        public ParkingTime Details { get; set; }
    }
}
