using System;
using static System.Console;

    class ElectroCar : Car
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

        public void ChargeCar(double chargeAmount)
        {
            if ((maxBatteryCapacity - currentChargeLevel) > chargeAmount)
            {
                currentChargeLevel += chargeAmount;
            }
            else
            {
                currentChargeLevel = maxBatteryCapacity;
            }
        }


        public override string GetCarDescription()
        {
            return $"Car description: Holder: {holderName},\n Number: {number},\n Type: {type},\n Battery capacity: {maxBatteryCapacity} Watt*Hour";
        }
    
        ~ElectroCar()
        {
            WriteLine("ElectroCar destructor called");
        }
    }
