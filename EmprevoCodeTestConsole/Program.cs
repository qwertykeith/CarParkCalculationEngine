using ParkingCostCalculatorEngine;
using ParkingCostCalculatorEngine.StaticData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprevoCodeTestConsole
{
    /// <summary>
    /// Simple console interface to test the parking price calculator
    /// </summary>
    class Program
    {
        const string dateFormat = "d/M/yyyy H:mm";

        static DateTime GetDate(string title)
        {
            DateTime? date = null;
            do
            {
                Console.WriteLine(title);
                Console.Write("> ");
                try
                {
                    var entryStr = Console.ReadLine();
                    date = DateTime.ParseExact(entryStr, dateFormat, CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid date!");
                    Console.WriteLine(string.Format("Date format should be {0}", dateFormat));
                    Console.WriteLine("Please try again ...");
                    Console.WriteLine();
                }
            } while (!date.HasValue);

            return date.Value;
        }

        static void Main(string[] args)
        {
            var rates = ParkingRatesProvider.GetRates();
            Console.WriteLine("Emprevo Parking Rate Calculator");
            Console.WriteLine();
            Console.WriteLine("Please enter times and dates for parking.");
            Console.WriteLine(string.Format("Date format should be in 24 hour time, formatted {0}", dateFormat));
            Console.WriteLine(string.Format("For example 2/2/2017 22:30"));
            Console.WriteLine();

            while (true)
            {
                var entryDate = GetDate("Vehicle entry date");
                var exitDate = GetDate("Vehicle exit date");

                try
                {
                    var result = rates.Calculate(new ParkingTimeModel()
                    {
                        Entry = entryDate,
                        Exit = exitDate,
                    });

                    Console.WriteLine();
                    Console.WriteLine(string.Format("{0}, {1}", result.RateName, result.Price.ToString("C")));
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();

            }


        }
    }
}
