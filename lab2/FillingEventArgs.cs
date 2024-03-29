using System;

    public class FillingEventArgs : EventArgs
    {
        private double fuelVolume;
        private double chargePower;

        public FillingEventArgs(double fuelVolume, double chargePower)
        {
            if (fuelVolume <= 0 || chargePower <= 0)
            {
                throw new FillArgumentsException(this);
            }
            this.fuelVolume = fuelVolume;
            this.chargePower = chargePower;
        }
        public FillingEventArgs() : this(1, 1000) {}
        public double FillVolume
        {
            get
            {
                return this.fuelVolume;
            }
            set
            {
                if (value > 0)
                {
                    this.fuelVolume = value;
                }
            }
        }
        public double Power
        {
            get
            {
                return chargePower;
            }
            set
            {
                if (value > 0)
                {
                    this.chargePower = value;
                }
            }
        }
    }
