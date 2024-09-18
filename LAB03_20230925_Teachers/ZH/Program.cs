using System;

namespace ZH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Group A
            /*
                Írjon egy programot, amely folyamatosan bekér a felhasználótól pozitív számokat. A 
                program érjen véget, ha a felhasználó negatív számot ad meg. A program kilépés előtt 
                jelenítse meg a bekért számok átlagát.
            */
            Console.Clear();
            int number = 0;
            int sum = 0;
            int counter = 0;
            do
            {
                Console.Write("Give number:\t");
                number = int.Parse(Console.ReadLine());
                sum += number;
                counter++;
            } while (number > -1);


            if (counter == 0)
            {
                Console.WriteLine("Average is 0");
            }
            else
            {
                Console.WriteLine($"Average is: {(double)sum / counter}");
            }

            #endregion

            #region Group B

            /*
                Írjon egy programot, amely bekér a felhasználótól 5 darab számot, majd pedig kiírja a 
                konzolra, ezek közül hány darab volt páros és melyik volt a legnagyobb.
             */
            Console.Clear();
            int cycleCounter = 0;
            int paircounter = 0;
            int maxValue = int.MinValue;
            do
            {
                Console.Write($"Give {++cycleCounter}. number:\t");
                number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    paircounter++;
                }
                if (number > maxValue)
                {
                    maxValue = number;
                }
            } while (cycleCounter < 5);

            Console.WriteLine($"Number of evens is: {paircounter}, highest is: {maxValue}.");
            #endregion
        }
    }
}
