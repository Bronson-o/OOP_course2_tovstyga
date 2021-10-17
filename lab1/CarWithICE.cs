using System;
using static System.Console;

    class CarWithICE : Car 
    {
        protected double maxTankCapacity;
        protected double currentFuelLevel = 0;

        static CarWithICE()
        {
            type = "ICE Car";
        }

        public CarWithICE(string name, string number, double maxTankCapacity) : base(name, number)
        {
            if (maxTankCapacity > 0)
            {
                this.maxTankCapacity = maxTankCapacity;    
            }
            else
            {
                this.maxTankCapacity = 0;
            }            
        }

        public CarWithICE() : base()
        {
            this.maxTankCapacity = 0;
        }

        public void FillCar(double fuelAmount)
        {
            if ((maxTankCapacity - currentFuelLevel) > fuelAmount)
            {
                currentFuelLevel += fuelAmount;
            }
            else
            {
                currentFuelLevel = maxTankCapacity;
            }
        }

        public override string GetCarDescription()
        {
            return $"Car description: Holder: {holderName},\n Number: {number}],\n Type: {type},\n Tank capacity: {maxTankCapacity} Litres";
        }
    
        ~CarWithICE()
        {
            WriteLine("CarWithICE destructor called");
        }
    }
