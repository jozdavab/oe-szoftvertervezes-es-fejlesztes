using System;

namespace HorgaszVerseny
{
    //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
    public class Program
    {
        static readonly Random rnd = new Random();   //Statikus random generátor. 1 van belőle az osztályban.

        static void Main(string[] args)
        {
            // Egy horgászverseny adatait egy kétdimenziós tömbben tároljuk: M(i,j) jelenti, hogy az i. horgász a j. halfajtából mennyit fogott.
            Console.WriteLine("ROW");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("COLUMN");
            int column = int.Parse(Console.ReadLine());

            Console.WriteLine("// 1. Az M mátrix adatait adhassa meg a felhasználó, illetve legyen lehetőség véletlenszerű feltöltésre is.");
            int[,] fishermenMatrix = MatrixMaker(row, column);

            Console.WriteLine("// 2. Az M mátrixot lehessen megjeleníteni a konzolon.");
            Console.WriteLine(ShowMatrix(fishermenMatrix));

            Console.WriteLine("// 3. Határozza meg, hogy a horgászok összesen mennyit fogtak az egyes halfajtákból.");
            Console.WriteLine(ShowMatrix(NumberOfAllCatches(fishermenMatrix)));

            Console.WriteLine("// 4. Határozza meg, hogy az egyes horgászok hány halat fogtak összesen.");
            Console.WriteLine(ShowMatrix(NumberOfCatchesByFishermen(fishermenMatrix)));

            Console.WriteLine("// 5. Van - e olyan horgász, aki nem fogott egyetlen halat sem?");
            Console.WriteLine(FishermenWithoutCatch(fishermenMatrix));

            Console.WriteLine("// 6. Hány olyan horgász van, aki nem fogott egyetlen halat sem?");
            Console.WriteLine(SumOfFishermenWithoutCatch(fishermenMatrix));

            Console.WriteLine("// 7. Melyik horgász fogta a legtöbb halat?");
            Console.WriteLine(bestFisherman(fishermenMatrix));

            Console.ReadKey();
        }

        static int[,] MatrixMaker(int x, int y)
        {
            int[,] matrix = new int[x, y];
            Console.WriteLine("{0}-Fill by hand\n{1}-AutoFill");

            if (Console.ReadLine() == "0")
            {
                FillByHand(matrix);
            }
            else
            {
                FillAutomatic(matrix);
            }

            return matrix;
        }

        static void FillByHand(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{i + 1}. fisherman's catches of {j + 1}. fish: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void FillAutomatic(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 101);
                }
            }
        }

        static string ShowMatrix(int[,] matrix)
        {
            string temp = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp += matrix[i, j] + "\t";
                }
                temp += "\n";
            }
            return temp;
        }

        static string ShowMatrix(int[] matrix)
        {
            string temp = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                temp += matrix[i] + "\t";
            }
            return temp;
        }

        static int[] NumberOfAllCatches(int[,] matrix)
        {
            int[] NumberOfCatchesByFish = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    NumberOfCatchesByFish[j] += matrix[i, j];
                }
            }
            return NumberOfCatchesByFish;
        }

        static int[] NumberOfCatchesByFishermen(int[,] matrix)
        {
            int[] fishermen = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    fishermen[i] += matrix[i, j];
                }
            }
            return fishermen;
        }
        static bool FishermenWithoutCatch(int[,] matrix)
        {
            bool exsists;
            int[] catchesByFishermen = NumberOfCatchesByFishermen(matrix);
            int i = 0;
            while (i < catchesByFishermen.Length && catchesByFishermen[i] != 0)
            {
                i++;
            }
            exsists = i < catchesByFishermen.Length;

            return exsists;
        }

        static int SumOfFishermenWithoutCatch(int[,] matrix)
        {
            int[] catchesByFishermen = NumberOfCatchesByFishermen(matrix);
            int counter = 0;
            for (int i = 0; i < catchesByFishermen.Length; i++)
            {
                if (catchesByFishermen[i] == 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        static int bestFisherman(int[,] matrix)
        {
            int[] catchesByFishermen = NumberOfCatchesByFishermen(matrix);
            int max = 0;
            for (int i = 1; i < catchesByFishermen.Length; i++)
            {
                if (catchesByFishermen[i] > catchesByFishermen[max])
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
