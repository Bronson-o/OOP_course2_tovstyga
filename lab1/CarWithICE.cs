using System;
using static System.Console;

    class CarWithICE : Car 
    {
        protected double maxTankCapacity;
        protected double currentFuelLevel = 0;

        static CarWithICE()
        {
            type = "Car with ICE";
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
            return $"Car description: holder: {holderName},\n number: {number}],\n type: {type},\n tank capacity: {maxTankCapacity} litres";
        }
    
        ~CarWithICE()
        {
            WriteLine("CarWithICE destructor called");
        }
    }
