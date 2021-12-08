using System;
using static System.Console;

    class Zaporozhets : CarWithICE
    {
        private DateTime productionDate;
        private double expensePer100Km;
        private static int price = 10000;
        private bool bought = false;

        private Zaporozhets()
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = 0;
        }

        private Zaporozhets(string name, string number, double tankCapacity, double expense) : base(name, number, tankCapacity)
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = expense;
        }


        public static Zaporozhets GetCar(string name, string number, double tankCapacity, double expense, int money)
        {
            if(money >= price)
            {
                return new Zaporozhets(name, number, tankCapacity, expense) {
                    bought = true
                };
            }
            else
            {
                return null;
            }
        }

        public static Zaporozhets GetCar(int money)
        {
            if(money >= price)
            {
                return new Zaporozhets(){
                    bought = true
                };
            }
            else
            {
                return null;
            }
            return new Zaporozhets(); 
        }


        public double Range
        {
            get
            {
                if (expensePer100Km != 0)
                {
                    return maxTankCapacity / expensePer100Km;
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

        public void OpenTrunk()
        {
            WriteLine("Trunk opened");
        }

        public override string GetCarDescription()
        {
            return $"Car description: - Holder: {holderName},\n Number: {number} \n" + 
            $"Type: {type}\n Tank Capacity: {maxTankCapacity} Litres\n" + 
            $"Production Date: {productionDate.ToString("d")}";
        }
    
        ~Zaporozhets()
        {
            WriteLine("Zaporozhets destructor called");
        }
    }
