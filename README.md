# Car park pricing calculation engine library

## How to use

There is a console app and unit tests included to demonstrate the engine (project is in VS2015 format).  
Here's how to use the calculator via client code.

Reference and include the calculator and rules

```
using ParkingCostCalculatorEngine;
using ParkingCostCalculatorEngine.StaticData;
```


Get the rules for calculating the rates

```
var rates = ParkingRatesProvider.GetRates();
```

_note: Rules could potentially come from another source such as database tables or JSON files as long as they use the models provided in the engine_

Use the extension method to calculate the rates

```
var result = rates.Calculate(new ParkingTimeModel()
{
    Entry = entryDate,
    Exit = exitDate,
});
```




## Libraries Explained

`EmprevoCodeTestConsole`

The console app to manually enter times and receive prices

`ParkingCostCalculatorEngine`

The price calculation engine and supporting models.

`ParkingCostCalculatorEngine.StaticData`

Provides rules used by the engine for calculating prices (hard coded in C# for the purposes of this exercise)

`ParkingCostCalculatorEngine.Tests`

Unit tests


## Notes

* Since the specs called for just an "engine" and there was no requirement at this stage to update plans or prices, no database (or subsequent UI) was provided.  The design allows for a database or text file to be plugged in easily at a later stage.
* "Calender day" is counted as 1 day for any day a car is parked, eg 23:55 Friday to 1:00 Saturday is 2 calendar days
* Excuse the complete lack of showing off with interfaces.  Anything involving DI or IOC seemed overkill for a simple task that could be achieved with a testable static method.
* The ExitTimeRule probably could have been implemented more neatly as a delegate, but this would mean the rates rules couldn't be provided in text form later, only by code
* Assumed "midnight Friday" means Friday night (ie Saturday morning 12am)


