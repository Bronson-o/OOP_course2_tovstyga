using System;
using static System.Console;

    class ElectroCar : Car, IElectroCar
    {
        protected double maxBatteryCapacity;
        protected double currentChargeLevel = 0;
        static ElectroCar()
        {
            type = "Electro Car";
        }
        public ElectroCar(string name, string number, double maxBatteryCapacity) : base(name, number)
        {
            if (maxBatteryCapacity > 0)
            {
                this.maxBatteryCapacity = maxBatteryCapacity;    
            }
            else
            {
                this.maxBatteryCapacity = 0;
            }            
        }
        public ElectroCar() : base()
        {
            this.maxBatteryCapacity = 0;
        }
        void IElectroCar.ChargeCar(RefuelingOperator oper, FillingEventArgs fArgs)
        {
            Action<RefuelingOperator> newClientReact = oper => WriteLine($"{oper.Fullname} see new client car, it's Electro car");
            newClientReact(oper);
            Func<double, double, double> calcPercent = (currValue, maxValue) => currValue / maxValue * 100;
            if ((maxBatteryCapacity - currentChargeLevel) > fArgs.Power)
            {
                currentChargeLevel += fArgs.Power;
                double currPercentCharge = calcPercent(currentChargeLevel, maxBatteryCapacity);
                WriteLine($"Car of holder: {holderName} charged by operator: {oper.Fullname}. Current charge: {currPercentCharge:f2} %");
            }
            else
            {
                currentChargeLevel = maxBatteryCapacity;

                WriteLine($"Car of holder: {holderName} charged by operator: {oper.Fullname}. Current charge: 100 %");
            }
            WriteLine();
        }
        public override string GetCarDescription()
        {
            return $" Car description: holder: {holderName}; number: {number};\n type: {type}] battery capacity: {maxBatteryCapacity} Watt * Hour";
        }
        public override void Drive(double distance)
        {
            Console.WriteLine($"The electro car drove {distance} km");
        }
    }
