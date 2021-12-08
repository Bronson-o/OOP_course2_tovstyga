using System;
using static System.Console;

    class RimacConceptOne : ElectroCar
    {
        private DateTime productionDate;
        private double expensePer100Km;
        private static int price = 100000;
        private bool bought = false;

        private RimacConceptOne()
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = 0;
        }

        private RimacConceptOne(string name, string number, double maxBatteryCapacity, double expense) : base(name, number, maxBatteryCapacity)
        {
            this.productionDate = DateTime.Now;
            
            this.expensePer100Km = expense;
        }


        public static RimacConceptOne GetCar(string name, string number, double maxBatteryCapacity, double expense, int money)
        {
            if(money >= price)
            {
                return new RimacConceptOne(name, number, maxBatteryCapacity, expense){
                    bought = true
                };
            }
            else
            {
                return null;
            }
        }

        public static RimacConceptOne GetCar(int money)
        {
            if(money >= price)
            {
                return new RimacConceptOne(){
                    bought = true
                };
            }
            else
            {
                return null;
            }
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
            return $"Car description: - Holder: {holderName} - Number: {number} -\n" + 
            $"- Type: {type} - Battery capacity: {maxBatteryCapacity} Watt * Hour -\n" + 
            $"- Production Date: {productionDate.ToString("d")} -";
        }

        ~RimacConceptOne()
        {
            WriteLine("RimacConceptOne destructor called");
        }
    }
