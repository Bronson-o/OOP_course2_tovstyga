using System;
using static System.Console;

    class Program
    {
        static void Main()
        {
            Car car = new Car("Arthurian", "CA1337CA");
            ElectroCar eCar = new ElectroCar("Yarichelo", "CA2288FF", 10000);
            CarWithICE iceCar = new CarWithICE("Maximus", "BH0000AK", 60);

            Zaporozhets zaporozhets = Zaporozhets.GetCar("Andrew", "AA1111EE", 70, 4);
            DisposeCars();
            WriteLine("\nMemory before creating 10000 obj: " + GC.GetTotalMemory(false));
            

            for (int i = 0; i < 10000; i++)
            {            
                Car car1 = new Car();
                car1.Dispose();
            }

            WriteLine($"Memory after creating 10000 obj: {GC.GetTotalMemory(false)}\n");
            WriteLine($"Generation of 'zaporozhets' obj before collecting: {GC.GetGeneration(zaporozhets)}\n");

            GC.Collect(2);
            GC.WaitForPendingFinalizers();
            
            WriteLine($"Memory after collecting garbage: {GC.GetTotalMemory(false)}\n");
            WriteLine($"Generation of 'zaporozhets' obj after collecting: {GC.GetGeneration(zaporozhets)}\n");
            WriteLine($"Garbage Collection count: {GC.CollectionCount(0)}");
        }

        private static void DisposeCars()
        {
            RimacConceptOne rimac = RimacConceptOne.GetCar();
            rimac.Dispose();
            GC.ReRegisterForFinalize(rimac);

            Zaporozhets zaporozhets = Zaporozhets.GetCar();
            zaporozhets.Dispose();
            GC.ReRegisterForFinalize(zaporozhets);
        }
    }


