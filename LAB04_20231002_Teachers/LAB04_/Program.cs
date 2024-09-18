using System;

namespace LAB04_20231002_Teachers
{
    internal class Program
    {
        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
        static void Main(string[] args)
        {
            int a = 3;
            int b = 2;
            int c;

            c = ADD(a, b);
            Console.WriteLine($"a:{a} b: {b} c:{c}");
            c = ADD(ref a, ref b);
            Console.WriteLine($"a:{a} b: {b} c:{c}");

            Console.WriteLine("Number 1:");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Number 2:");
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Op:");
            string op = Console.ReadLine();

            Console.WriteLine($"The result is: {Calculator(num1, num2, op)}");

            Console.ReadKey();
        }

        static int ADD(int a, int b)            //Érték szerinti átadás
        {
            int c = a + b;
            a = 0;
            b = 0;
            return c;
        }

        /*static int ADD(int szam1, int szam2)  //Kikommentelés fordítási hibát okozna! Szignatúra azonos az előző metódussal.
        {
            return szam1 + szam2;
        }*/

        static int ADD(ref int a, ref int b)    //Referencia szerinti átadás. Metódus túlterhelés az eltérő paraméterek miatt --> Szignatúra eltér. 
        {
            int c = a + b;
            a = 0;
            b = 0;
            return c;
        }



        // 3DB /// al generálhatunk függvénydokumentációt
        /// <summary>
        /// Elvégzi az átadott műveleti jelnek megfelelő műveletet, az átadott változók között, majd visszadja az eredményt.
        /// </summary>
        /// <param name="a">Első változó</param>
        /// <param name="b">Második változó</param>
        /// <param name="operation">Változók között elvégzendő művelet</param>
        /// <returns>A és B változó közötti művelet eredménye</returns>
        static double Calculator(double a, double b, string operation)
        {
            double result;
            if (operation == "+")
            {
                result = a + b;
            }
            else if (operation == "-")
            {
                result = a - b;
            }
            else if (operation == "*")
            {
                result = a * b;
            }
            else
            {
                result = a / b;
            }

            return result;
        }
    }
}
