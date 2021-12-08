/*
Реалізувати різноманітні методи проведення віртуального медичного огляду
лікарями як мінімум трьох спеціалізацій (стоматолог, хірург, ортопед і т.ін.).
Забезпечити підтримку віртуального медичного огляду певною множиною лікарів. 
*/

using System;
using static System.Console;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicalExamitaion ex = new MedicalExamitaion("Shevchenko", "Petrashenko", "Rebrov", "Myhailichenko", "Lobanovskyi");
            ex.To_Examine();
        }
    }

    class MedicalExamitaion
    {
        Dentist dentist;
        Surgeon surgeon;
        Traumatologist traumatologist;
        Urologist urologist;
        Otorhinolaryngologist otorhinolaryngologist;

        public MedicalExamitaion(string surgeon_name, string dentist_name, 
            string traumatologist_name, string urologist_name, string otorhinolaryngologist_name)
        {
            surgeon = new Surgeon(surgeon_name, 27);
            dentist = new Dentist(dentist_name, 65);
            traumatologist = new Traumatologist(traumatologist_name, 54);
            urologist = new Urologist(urologist_name, 20);
            otorhinolaryngologist = new Otorhinolaryngologist(otorhinolaryngologist_name, 45);
        }
        public void To_Examine()
        {
            dentist.Examine();
            urologist.Examine();
            surgeon.Examine();
            traumatologist.Examine();
            otorhinolaryngologist.Examine();
            otorhinolaryngologist.FinishExamination();
            traumatologist.FinishExamination();
        }
    }
    abstract class Doctor
    {
        public string name;
        private int age;
        public int Age { get { return age; } set { if (value >= 20) { age = value; } } }
        public abstract void Examine();
    }
    class Surgeon : Doctor
    {
        public Surgeon(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public override void Examine()
        {
            WriteLine("Surgeon - U are ok!.");
        }
    }
    class Dentist : Doctor
    {
        public Dentist(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public override void Examine()
        {
            WriteLine("Dentist - Your teeth is OK. U can relax!");
        }
    }
    class Traumatologist : Doctor
    {
        public Traumatologist(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public override void Examine()
        {
            WriteLine("Traumatologist - Do an X-ray.");
        }

        public void FinishExamination()
        {
            WriteLine("Traumatologist - Your foot is not OK, i will fix it!");
        }
    }
    class Urologist : Doctor
    {
        public Urologist(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public override void Examine()
        {
            WriteLine("Urologist - Gratz, it's ok!");
        }
    }
    class Otorhinolaryngologist : Doctor
    {
        public Otorhinolaryngologist(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public override void Examine()
        {
            WriteLine("Otorhinolaryngologist - Do cardiogram");
        }

        public void FinishExamination()
        {
            WriteLine("Otorhinolaryngologist - Your heart is OK.");
        }
    }
}
