using System;
using static System.Console;

    class Car : IDisposable
    {
        protected string number;
        protected string holderName;
        protected static string type;
        protected bool disposed;


        public Car()
        {
            this.number = "unknown";
            this.holderName = "unknown";
        }

        public Car(string name, string number)
        {
            this.number = number;
            this.holderName = name;
        }

        public virtual string GetCarDescription()
        {
            return $"Car description: Holder - {holderName},\n Number - {number}";
        }

        public virtual void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        protected void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {}

                disposed = true;
            }
        }

        ~Car()
        {
            CleanUp(false);
            WriteLine("Car destructor called");
        }
    }
