using System;

namespace KisZH
{
    //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
    public class Program
    {
        static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            /*
             *  Hozzon létre egy 5 - 15 közötti véletlen mérettel rendelkező, egész számokat tartalmazó tömböt!
             *  Töltse fel a tömböt véletlenszerűen generált számokkal a következő szabálynak megfelelően:
             *  -10 <= x <= 29, ahol x a tömb egy adott elemének értéke.
             */
            int[] array = new int[rnd.Next(5, 6)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10, 30);
            }

            /*
             *  Jelenítse meg a konzolon a tömb értékeit!
             */
            Console.Write("Elements of the array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }

            /*
             *  Jelenítse meg a konzolon hány negatív szám, pozitív szám és hármas van a tömbben.
             */
            int threeCount = 0;
            int positives = 0;
            int negatives = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    positives++;
                    if (array[i] == 3)
                    {
                        threeCount++;
                    }
                }
                else if (array[i] < 0)
                {
                    negatives++;
                }
            }

            Console.WriteLine($"\npositives: {positives}, threes:{threeCount}, negatives:{negatives}");

            /*
             *  Jelenítse meg a konzolon mely indexen található a tömb legkisebb eleme, és mi ennek az értéke.
             */
            int mini = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[mini])
                {
                    mini = i;
                }
            }

            Console.WriteLine($"Min element at: {mini}, with value of: {array[mini]}");
            Console.ReadKey();
        }
    }
}
