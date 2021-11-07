using System;
using static System.Console;

    class CarWithICE : Car, ICarWithICE
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
        void ICarWithICE.FillCar(RefuelingOperator oper, FillingEventArgs fArgs)
        {
            Action<RefuelingOperator> newClientReact = oper => WriteLine($"{oper.Fullname}] see new client car, it's Car with ICE");
            newClientReact(oper);
            Func<double, double, double> calcPercent = (currValue, maxValue) => currValue / maxValue * 100;
            if ((maxTankCapacity - currentFuelLevel) > fArgs.FillVolume)
            {
                currentFuelLevel += fArgs.FillVolume;
                double currPercentFill = calcPercent(currentFuelLevel, maxTankCapacity);
                WriteLine($"Car of holder: {holderName} filled by operator: {oper.Fullname}. Current fill: {currPercentFill:f2} %");
            }
            else
            {
                currentFuelLevel = maxTankCapacity;
                WriteLine($"Car of holder: {holderName} filled by operator: {oper.Fullname}. Current fill: 100 %");
            }
            WriteLine();
        }

        public override string GetCarDescription()
        {
            return $" Car description: holder: {holderName}; number: {number};\n type: {type} tank capacity: {maxTankCapacity} litres]";
        }

        public override void Drive(double distance)
        {
            WriteLine($"The car wtih ICE drove {distance} km");
        }
    }
