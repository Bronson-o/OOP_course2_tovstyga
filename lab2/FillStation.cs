using System;
    class FillStation
    {
        public FillStation(RefuelingOperator oper)
        {
            IElectroCar[] electroCars = new ElectroCar[2];
            electroCars[0] = RimacConceptOne.GetCar();
            electroCars[1] = RimacConceptOne.GetCar("DragonKnight", "RR0231YY", 300000, 54666);

            ICarWithICE[] carsWithICE = new CarWithICE[2];
            carsWithICE[0] = Zaporozhets.GetCar();
            carsWithICE[1] = Zaporozhets.GetCar("Dota2", "ff1323DJ", 300, 6);

            for (int i = 0; i < 2; i++)
            {
                oper.FillingEvent += new FillingHandle(electroCars[i].ChargeCar);
                oper.FillingEvent += new FillingHandle(carsWithICE[i].FillCar);
            }
        }
    }
