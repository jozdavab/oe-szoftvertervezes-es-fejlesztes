using System;
using System.Xml.Linq;

namespace LAB06_20231016_Teachers
{
    //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
    public class Program
    {
        static void Main(string[] args)
        {
            //A
            int[] array = { 1, 2, -4, 3, 6, 7, 5, 5, 0, 9 };
            int modifications = TaskA(array);
            Console.WriteLine("Elemets of array:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine($"\nArray ordered by {modifications} modifications\n\n");

            //B
            int[] test1 = { 0, 1, 2, 3, 4, 4 };
            int[] test2 = { 4, 4, 3, 2, 1, 0 };
            int[] test3 = { 0, 1, 2, 4, 3, 4 };
            Console.WriteLine(TaskB(test1));
            Console.WriteLine(TaskB(test2));
            Console.WriteLine(TaskB(test3));

            Console.ReadKey();
        }

        //A csoport
        // Írjon egy statikus, egész számot visszaadó metódust, melynek bemeneti paramétere egy egész számokat tartalmazó tömb.
        //A metóduson belül járja be a tömböt, és helyben rendezze a tömb elemeit növekvő sorrendbe
        //A metódus adja vissza, hányszor kellett a tömb bármely elemének új értéket adnia. (array[index] = érték)
        //Hívja meg a metódust! Jelenítse meg az értékadások számát és a tömb elemeit.
        //Használja a következő tömböt a teszteléshez:
        //int[] array = { 1, 2, -4, 3, 6, 7, 5, 5, 0, 9 };
        static int TaskA(int[] array)
        {
            int counter = 0;
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                int temp = array[i];
                while (j > -1 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                    counter++;
                }
                array[j + 1] = temp;
                counter++;
            }
            return counter;
        }


        //B csoport
        //Írjon egy statikus metódust, amely 
        //    bemeneti paraméterként vár egy egész számokból álló tömböt,
        //    Szöveg típussal tér vissza
        //A függvényben ne használjon Console utasítást! 
        //Járja be a tömböt és valamely módon tárolja el a megfelelő relációs jelet minden elem közé.
        //Állapítsa meg hogy a tömb elemei rendezettek vagy rendezetlenek, és ha rendezettek, akkor növekvő, vagy csökkenő módon.
        //Adja vissza szövegként a feldolgozott információkat.
        //A main metódusban hozzon létre teszt tömböket mindhárom lehetséges teszt esetre, (növekvő tömb, csökkenő tömb, rendezetlen tömb).
        //Hívja meg a függvényét, a teszt adatokkal, és jelenítse meg konzolon az eredményt.
        static string TaskB(int[] array)
        {
            string s = "";
            bool increasing = false;
            bool decreasing = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                s += array[i];
                if (array[i] < array[i + 1])
                {
                    s += " < ";
                    increasing = true;
                }
                else if (array[i] > array[i + 1])
                {
                    s += " > ";
                    decreasing = true;
                }
                else
                {
                    s += " = ";
                }
            }

            s += $"{array[array.Length - 1]}\n";

            if (increasing && decreasing)
            {
                s += "Unordered";
            }
            else if (increasing)
            {
                s += "Ordered ascending";
            }
            else
            {
                s += "Ordered descending";
            }
            s += "\n";

            return s;
        }
    }
}
