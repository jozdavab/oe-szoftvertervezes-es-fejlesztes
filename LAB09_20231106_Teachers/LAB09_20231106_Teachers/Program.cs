using System;

namespace LAB09_20231106_Teachers
{
    //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
    public class Program
    {
        static void Main(string[] args)
        {
            #region Propertyk

            Console.WriteLine("----------TASK 1----------");
            Student nebulo1 = new Student("David", 26, "OE");
            Console.WriteLine(nebulo1.ShowMe());

            nebulo1.Age++;
            Console.WriteLine(nebulo1.ShowMe());

            nebulo1.Age = -26;
            Console.WriteLine(nebulo1.ShowMe());

            nebulo1.University = "BME";
            Console.WriteLine(nebulo1.ShowMe());

            //nebulo1.Name = "Átnevezlek";  //Hiba, csak olvasható!
            #endregion

            #region Bank

            BankAccount ba1 = new BankAccount("01234567-01234567", "Person1", 20);
            Console.WriteLine(ba1.ShowMe());
            BankAccount ba2 = new BankAccount("12345678-12345678", "Person2");
            Console.WriteLine(ba2.ShowMe());
            BankAccount ba3 = new BankAccount("Person3", 20);
            Console.WriteLine(ba3.ShowMe());
            BankAccount ba4 = new BankAccount("Person4");
            Console.WriteLine(ba4.ShowMe());
            BankAccount ba5 = new BankAccount();
            Console.WriteLine(ba5.ShowMe());

            //Tesztelések: 

            bool first = ba1.Pay(20);
            if (first)
            {
                Console.WriteLine(ba1.ShowMe());
            }

            bool second = ba1.Pay(20);
            if (second)
            {
                Console.WriteLine(ba1.ShowMe());
            }

            bool third = ba1.Increase(100);
            if (third)
            {
                Console.WriteLine(ba1.ShowMe());
            }

            bool fourth = ba1.Interest((decimal)1.1);
            if (fourth)
            {
                Console.WriteLine(ba1.ShowMe());
            }


            bool fifth = ba1.Increase(decimal.MaxValue);
            if (fifth)
            {
                Console.WriteLine(ba1.ShowMe());
            }

            Console.Clear();

            Console.WriteLine(ba1.ShowMe());
            Console.WriteLine(ba2.ShowMe());
            bool sixth = ba1.SendMoney(20, ba2);
            if (sixth)
            {
                Console.WriteLine(ba1.ShowMe());
                Console.WriteLine(ba2.ShowMe());
            }
            #endregion

            Console.ReadKey();
        }
    }
}
