using System;

namespace FutballBajnokság
{
    internal class Program
    {
        static Random rnd = new Random();

        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
        static void Main(string[] args)
        {
            /*
             * Készítsen programot, amely egy kispályás futball bajnokság ponttábláját kezeli.
             * A bajnokságon 6 csapat vesz részt.
             * A csapatok neveit a csapatok tömbben tároljuk, ezek előre adottak a programban.
             * A bajnokság ponttáblája az eredmenyek tömbben van.
             * Az eredmenyek[i,j] értéke
                * 0, ha az i-edik csapat otthon kikapott a j-edik csapattól,
                * 1, ha a két csapat az i-edik csapat otthonában döntetlent játszott,
                * 3, ha az i-edik csapat otthon legyőzte a j-edik csapatot.
            */
            FutballBajnokság();
            Console.ReadKey();
        }

        static void FutballBajnokság()
        {
            string[] csapatok = new string[] { "Budapest", "Győr", "Debrecen", "Pécs", "Paks", "Kecskemét" }; //6 random kiválasztott csapat

            int[,] eredmenyek = new int[csapatok.Length, csapatok.Length]; //Mivel 6 csapatot vettünk fel, 6x6 os tömb.

            Fetolt(eredmenyek);                                             //tömb->Referencia szerinti átadás. Az eredeti tömb is módosul.

            Megjelenit(csapatok, eredmenyek);

            //Ternary operator : https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
            Console.WriteLine($"A Szombathely csapat játszik a bajnokságban? {(IndultE(csapatok, "Szombathely") != -1 ? "Igen" : "Nem")}");

            Console.WriteLine($"A Budapest csapat pontjai: {Pontszam(eredmenyek, 0)}");

            int[] pontszamok = PontTabla(eredmenyek);

            for (int i = 0; i < pontszamok.Length; i++)
            {
                Console.WriteLine($"{csapatok[i]} pontjai: {pontszamok[i]}");
            }

            int gyoztes = Nyertes(pontszamok);

            Console.WriteLine($"A nyertes a {csapatok[gyoztes]} csapata.");

            Console.ReadKey();
        }

        //Írjon metódust, amely az eredmenyek tömb elemeit feltölti véletlen értékekkel.Természetesen eredmenyek[i, i] minden esetben 0 lesz.
        static void Fetolt(int[,] eredmenyek)
        {
            for (int i = 0; i < eredmenyek.GetLength(0); i++)
            {
                for (int j = 0; j < eredmenyek.GetLength(1); j++)
                {
                    if (i == j) //átló
                    {
                        eredmenyek[i, j] = 0;
                    }
                    else
                    {
                        int esely = rnd.Next(0, 101);
                        if (esely < 34)
                        {
                            eredmenyek[i, j] = 0;
                        }
                        else if (esely < 67)
                        {
                            eredmenyek[i, j] = 1;
                        }
                        else
                        {
                            eredmenyek[i, j] = 3;
                        }
                    }
                }
            }
        }

        //Írjon metódust, amely segítségével megjeleníthetők az eredmények.
        static void Megjelenit(string[] csapatok, int[,] eredmenyek)
        {
            for (int i = 0; i < eredmenyek.GetLength(0); i++)
            {
                Console.Write(csapatok[i] + "eredményei:\t");
                for (int j = 0; j < eredmenyek.GetLength(1); j++)
                {
                    Console.Write(eredmenyek[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }


        //Írjon metódust, amellyel eldönthető, hogy egy adott nevű csapat indult-e a bajnokságban.
        //Ha indult, akkor az adott csapat csapatok tömbbeli indexét adja vissza a metódus, egyébként pedig -1- et.
        static int IndultE(string[] csapatok, string nev)
        {
            for (int i = 0; i < csapatok.Length; i++)
            {
                if (csapatok[i] == nev)
                {
                    return i; //Eldöntés tétellel is lehetne, de a return miatt a függvényből kilépünk találat esetén, ezért így is hatékony megoldás.
                }
            }
            return -1;
        }

        //Írjon metódust, amely meghatározza, hogy egy adott csapat összesen hány pontot ért el a bajnokságban.
        //(Ez az adott csapat eredmenyek tömbbeli sorának és oszlopának összegeként adható meg.)
        static int Pontszam(int[,] eredmenyek, int index)
        {
            int pontszam = 0;

            for (int i = 0; i < eredmenyek.GetLength(1); i++)
            {
                pontszam += eredmenyek[index, i];
            }

            return pontszam;
        }

        //Írjon metódust, amely segítségével egy új tömbben előállítható a bajnokság minden egyes csapatára, hogy összesen hány pontot szereztek.
        static int[] PontTabla(int[,] eredmenyek)
        {
            int[] pontok = new int[eredmenyek.GetLength(0)];

            for (int i = 0; i < eredmenyek.GetLength(0); i++)
            {
                pontok[i] = Pontszam(eredmenyek, i);
            }

            return pontok;
        }

        //Írjon metódust, amely megadja, hogy melyik csapat nyerte a bajnokságot.
        //(Ha több csapat is maximális pontszámot szerzett, akkor közülük az első csapatot hozza ki nyertesnek.)
        static int Nyertes(int[] pontok)
        {
            int max = 0;

            for (int i = 1; i < pontok.Length; i++)
            {
                if (pontok[i] > pontok[max])
                {
                    max = i;
                }
            }

            return max;
        }
    }
}
