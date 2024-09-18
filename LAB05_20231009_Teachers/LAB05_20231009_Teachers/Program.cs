using System;

namespace LAB05_20231009_Teachers
{
    public class Program
    {
        static readonly Random rnd = new Random();

        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
        static void Main(string[] args)
        {
            Console.Write("Give row: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Give column: ");
            int y = int.Parse(Console.ReadLine());
            int[,] array = Task3A(x, y);

            string sign = "\t<-- * -->\t";
            Task3B(array, sign);

            Task3C(array, 2, 10);
        }


        /*
        Írjon egy statikus metódust, melynek visszatérési értéke egy egész számokból álló 2 dimenziós mátrix
        Bemeneti paraméterei pedig: 
            A mátrix oszlopainak száma (egész) 
            A mátrix sorainak száma (egész)
        A metódus hozza létre a bemeneti paramétereknek megfelelő egész számokból álló mátrixot!
        Járja be a mátrixot és töltse fel véletlenszerűen generált, egész értékekkel!
        Ügyeljen rá, hogy a véletlenszerűen generált értékek mindig eltérő tartományokba essenek, úgy,
        hogy az első cellába 0-9 közötti számot generáljon, a második cellába 10-19 közöttit,
        és így tovább 10-zel növekedve egészen az utolsó celláig.
        A main metódusban kérje be a felhasználótól a megfelelő paramétereket,majd azok felhasználásával hívja meg a metódust!
        Jelenítse meg konzolon a kapott mátrixot
        */
        static int[,] Task3A(int x, int y)
        {
            int[,] array = new int[x, y];
            int min = 0;
            int max = min + 10;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(min, max);
                    min += 10;
                    max = min + 10;
                }
            }

            return array;
        }

        /*
         Készítsen egy visszatérési érték nélküli, statikus metódust, melynek bemeneti paraméterei:
            Egy egész számokból álló, 2 dimenziós mátrix
            Egy szöveg típusú „elválasztó” jel
        A metódus jelenítse meg a konzolon, a bemenetként kapott mátrix szélességét, hosszúságát és elemszámát!
        Ezután a metódus jelenítse meg a bemeneti mátrix elemeit formázott módon:
        Az elemek legyenek sorokba és oszlopokba rendezve
        Azonos sorban lévő elemek között szerepeljen az elválasztójel.
        A sor utolsó eleme után vagy első eleme előtt ne szerepeljen az elválasztójel.
        Hívja meg a metódust! Használja a következő példamátrixot teszteléshez:
        int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
         */
        static void Task3B(int[,] array, string formatter)
        {
            Console.WriteLine($"Dimensions of array: X:{array.GetLength(0)} Y:{array.GetLength(1)} Count:{array.Length}\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    if (j < array.GetLength(1) - 1)
                    {
                        Console.Write(formatter);
                    }
                }
                Console.WriteLine();
            }
        }

        /*
         Készítsen egy visszatérési érték nélküli, statikus metódust, melynek bemeneti paraméterei:
            Egy egész számokból álló, 2 dimenziós mátrix
            A mátrix elemeinek maximum értéke (egész)
            A mátrix elemeinek minimum értéke (egész)
        A metódus járja be a mátrixot és ellenőrizze értékeit.
        Ahol a cellaérték a megadott minimum és maximum tartományon kívül esik, ott generáljon egy új, kritériumoknak megfelelő véletlenszerű értéket.
        Számolja meg és írja ki a konzolra, hányszor kellett új értéket generálnia.
        Hívja meg a metódust! Használja a következő példamátrixot teszteléshez:
        int[,] array = { { -1, 2, 3 }, { 4, 5, 6 }, { 70, 80, 90 } };
         */
        static void Task3C(int[,] array, int min, int max)
        {
            int counter = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min || array[i, j] > max)
                    {
                        array[i, j] = rnd.Next(min, max);
                        counter++;
                    }
                }
            }
            Console.WriteLine($"I switched {counter} times");
        }

    }
}
