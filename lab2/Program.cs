using System;
using static System.Console;
    public delegate void FillingHandle(RefuelingOperator oper, FillingEventArgs fArgs);
    class Program
    {
        static void Main(string[] args)
        {
            RefuelingOperator oper = new RefuelingOperator("Andryi", "Shevchenko");
            FillStation station = new FillStation(oper);
            oper.FillUp();
            
            FillingHandle currentFillInfo = delegate(RefuelingOperator oper, FillingEventArgs fArgs)
            {
                WriteLine($"Current filling/charging operator: {oper.Fullname}; Current filling volume: {fArgs.FillVolume} litres; current charging power: {fArgs.Power} Watt");
            };
            currentFillInfo(oper, oper.fArgs);
            WriteLine();

            RimacConceptOne rimac = RimacConceptOne.GetCar("MyFriend", "BB1111FF", 200000, 1);
            rimac.OnSportMode();
        }
    }

