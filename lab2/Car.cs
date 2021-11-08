using System;
using static System.Console;

    abstract class Car : IDisposable
    {
        protected string holderName;
        protected string number;
        protected static string type = "unknown";
        protected bool disposed;


        public Car()
        {
            this.holderName = "unknown";
            this.number = "unknown";
        }
        public Car(string name, string numbers)
        {
            this.holderName = name;
            this.number = numbers;
        }
        public virtual string GetCarDescription()
        {
            return $"Car description: Holder: {holderName}; Number: {number}";
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
                {

                } 
                disposed = true;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public abstract void Drive(double distance);
    }
