using System;
using static System.Console;
    public class RefuelingOperator
    {
        public event FillingHandle FillingEvent;
        public FillingEventArgs fArgs;
        private string name;
        private string surname;

        public RefuelingOperator()
        {
            this.name = "unknown";
            this.surname = "";
        }

        public RefuelingOperator(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public void FillUp()
        {
            double volume, power;
            FillingEventArgs fillArgs = null;
        
            try
            {
                Write("Enter filling volume: ");
                volume = Double.Parse(ReadLine());

                Write("Enter charge power: ");
                power = Double.Parse(ReadLine());

                fillArgs = new FillingEventArgs(volume, power);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                WriteLine("Set to default values: Fill volume: 1 liter; Charge power: 1000 Watt");

                fillArgs = new FillingEventArgs();
            }
            finally
            {
                fArgs = fillArgs;

                WriteLine();
                WriteLine($"Operator {this.name} is responsible for filling cars.");
                WriteLine();
                if (FillingEvent != null)
                {
                    FillingEvent((RefuelingOperator)this, fillArgs);
                }   
            }
        }
    
        public string Fullname
        {
            get
            {
                return $"{this.name} {this.surname}";
            }
        }
    }