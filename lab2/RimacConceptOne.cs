using System;
using static System.Console;

    class RimacConceptOne : ElectroCar, IElectroCar, IRimacConceptOne
    {
        private DateTime productionDate;
        private double expensePer100Km;

        private RimacConceptOne() : base()
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = 0;
        }

        private RimacConceptOne(string name, string number, double maxBatteryCapacity, double expense) : base(name, number, maxBatteryCapacity)
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = expense;
        }


        public static RimacConceptOne GetCar(string name, string number, double maxBatteryCapacity, double expense)
        {
            return new RimacConceptOne(name, number, maxBatteryCapacity, expense); 
        }

        public static RimacConceptOne GetCar()
        {
            return new RimacConceptOne(); 
        }


        public double Range
        {
            get
            {
                if (expensePer100Km != 0)
                {
                    return maxBatteryCapacity / expensePer100Km;
                }
                else
                {
                    return -1;
                }
            }
        }

        public double ExpensePer100Km
        {
            get
            {
                return expensePer100Km;
            }
            set
            {
                if (value > 0)
                {
                    this.expensePer100Km = value;
                }
                else
                {
                    this.expensePer100Km = 0;
                }
            }
        }

        public void RemoteOpenDoor()
        {
            WriteLine($"Door opened");
        }

        public override string GetCarDescription()
        {
            return $" Car description: - holder: {holderName} - number: {number} -\n" + 
            $"type: {type} - battery capacity: {maxBatteryCapacity} Watt*Hour -\n" + 
            $"production Date: {productionDate.ToString("d")} -";
        }
    
        public override void Drive(double distance)
        {   
            Console.WriteLine($"Rimac Concept One drove {distance} km");
        }
    }
