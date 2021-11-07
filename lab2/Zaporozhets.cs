using System;
using static System.Console;

    class Zaporozhets : CarWithICE, ICarWithICE, IZaporozhets
    {
        private DateTime productionDate;
        private double expensePer100Km;

        private Zaporozhets() : base()
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = 0;
        }

        private Zaporozhets(string name, string number, double tankCapacity, double expense) : base(name, number, tankCapacity)
        {
            this.productionDate = DateTime.Now;
            this.expensePer100Km = expense;
        }
        public static Zaporozhets GetCar(string name, string number, double tankCapacity, double expense)
        {
            return new Zaporozhets(name, number, tankCapacity, expense); 
        }
        public static Zaporozhets GetCar()
        {
            return new Zaporozhets(); 
        }
        public double Range
        {
            get
            {
                if (expensePer100Km != 0)
                {
                    return maxTankCapacity/expensePer100Km;
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
            return $" Car description: - holder: {holderName} - number: {number} -\n" + 
            $"type: {type} - battery capacity: {maxTankCapacity} Watt*Hour -\n" + 
            $"production Date: {productionDate.ToString("d")} -";
        }
        public override void Drive(double distance)
        {   
            WriteLine($"Zaporozhets drove {distance} km");
        }
    }
