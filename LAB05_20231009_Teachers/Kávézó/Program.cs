using System;

namespace Kávézó
{
    internal class Program
    {
        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
        static void Main(string[] args)
        {
            /* 
            * Írjon programot egy kávézó napi forgalmi adatainak kezelésére!
                * 1.A programban megadható, hogy hány nap adatait akarjuk eltárolni.
                * 2.Minden napnál megadható legfeljebb 10 ital, amit aznap felszolgáltak.
                * 3. A program képes megadni, hogy a vizsgált napokon milyen italokat szolgáltak fel.
                * 4.Minden ital esetén meg lehet határozni, hogy hány esetben szolgálták fel.
            */
            Kavezo();
            Console.ReadKey();
        }

        static void Kavezo()
        {
            //1 && 2
            string[,] italokNaponta = EladottItalokBekerese(BekerNapokSzama());

            // 3
            Console.WriteLine("Melyik nap adataira kíváncsi?");
            int napIndex = int.Parse(Console.ReadLine());
            string[] adottNapiItalok = AdottNapotKivalogat(italokNaponta, napIndex - 1);

            // 4
            int[] italonkentEladottMennyisegek = EladottMennyisegek(italokNaponta, Italok(italokNaponta));
        }

        //int BekerNapokSzama() Bekéri a vizsgált napok számát.
        static int BekerNapokSzama()
        {
            Console.WriteLine("Add meg hány nap adatait akarjuk eltárolni!");
            int napok = int.Parse(Console.ReadLine());

            return napok;
        }

        //string[,] EladottItalokBekerese()
        //Bekéri az egyes napokon eladott italok listáját.
        static string[,] EladottItalokBekerese(int napok)
        {
            string[,] italok = new string[napok, 10];

            for (int i = 0; i < italok.GetLength(0); i++)
            {
                Console.WriteLine($"{i + 1}. nap italai: ");
                int j = 0;
                string ital;
                do
                {
                    Console.WriteLine($"Add meg az {i + 1}. nap, {j + 1}.italát:");
                    ital = Console.ReadLine();
                    italok[i, j] = ital;
                    j++;
                } while (j < 10 && ital != string.Empty);
                Console.Clear();
            }

            return italok;
        }

        //int AdottNapiItalokSzama(string[,] italokNaponta, int index)
        //Megadja, hogy adott napon hány darab italt fogyasztottak el.
        static int AdottNapiItalokSzama(string[,] italokNaponta, int napIndex)
        {
            int db = 0;

            for (int i = 0; i < italokNaponta.GetLength(1); i++)
            {
                if (italokNaponta[napIndex, i] != null)
                {
                    db++;
                }
            }

            return db;
        }

        //string[] AdottNapotKivalogat(string[,] italokNaponta, int index)
        //Az adott nap italait kiválogatja.A kimenet hossza megegyezik a tényleges fogyasztási mennyiséggel.
        static string[] AdottNapotKivalogat(string[,] italokNaponta, int napIndex)
        {
            int db = AdottNapiItalokSzama(italokNaponta, napIndex);
            string[] italok = new string[db];

            for (int i = 0; i < db; i++)
            {
                italok[i] = italokNaponta[napIndex, i];
            }

            return italok;
        }

        //bool StringKisebbE(string elso, string masodik)
        //Összehasonlítja a két bemeneti stringet.
        static bool StringKisebbE(string elso, string masodik)
        {
            int i = 0;
            while (i < elso.Length && i < masodik.Length && elso[i] == masodik[i])
            {
                i++;
            }
            if (i >= elso.Length)
            {
                return true;
            }
            else if (i >= masodik.Length)
            {
                return false;
            }
            return elso[i] < masodik[i];
        }

        //void NapiItalListatRendez(string[] italok)
        //A bemeneti tömböt növekvő módon rendezi.
        static void NapiItalListatRendez(string[] italok)
        {
            for (int i = 0; i < italok.Length - 1; i++)
            {
                for (int j = i + 1; j < italok.Length; j++)
                {
                    if (StringKisebbE(italok[i], italok[j]))
                    {
                        string tmp = italok[i];
                        italok[i] = italok[j];
                        italok[j] = tmp;
                    }
                }
            }
        }

        //string[] IsmetlodoItalokKiszurese(string[] italok)
        //A rendezett bemeneti tömbből kiszűri az ismétlődő elemeket. A kimeneti tömb mérete megegyezik a benne ténylegesen eltárolt italok számával.
        static string[] IsmetlodoItalokKiszurese(string[] italok)
        {
            int db = 0;
            for (int i = 1; i < italok.Length; i++)
            {
                if (italok[i - 1] != italok[i])
                {
                    db++;
                }
            }

            string[] ujItalok = new string[db];
            db = 0;
            for (int i = 1; i < italok.Length; i++)
            {
                if (italok[i - 1] != italok[i])
                {
                    ujItalok[db++] = italok[i];
                }
            }

            return ujItalok;
        }

        //string[] KetListatOsszefuttat(string[] elsoLista, string[] masodikLista)
        //Az összefuttatás tételt alkalmazva összefuttatja a két rendezett bemeneti tömböt. A kimeneti tömb mérete megegyezik a benne eltárolt italok számával.
        static string[] KetListatOsszefuttat(string[] x1, string[] x2)
        {
            string[] y = new string[x1.Length + x2.Length];
            int i = 0;
            int j = 0;
            int db = -1;
            while (i < x1.Length && j < x2.Length)
            {
                db++;
                if (StringKisebbE(x1[i], x2[j]))
                {
                    y[db] = x1[i];
                    i++;
                }
                else
                {
                    if (StringKisebbE(x2[i], x1[j]))
                    {
                        y[db] = x2[i];
                        j++;
                    }
                    else
                    {
                        y[db] = x1[i];
                        i++;
                        j++;
                    }
                }
            }
            while (i < x1.Length)
            {
                db++;
                y[db] = x1[i];
                i++;
            }
            while (j < x2.Length)
            {
                db++;
                y[db] = x2[j];
                j++;
            }
            return y;
        }

        //string[] Italok(string[,] italokNaponta)
        //Visszaadja a bemeneti tömbben található italok rendezett és ismétlődésmentes listáját.
        static string[] Italok(string[,] italokNaponta)
        {
            string[] osszesItalNev = new string[0];
            for (int i = 0; i < italokNaponta.GetLength(0); i++)
            {
                string[] adottNapiItalok = AdottNapotKivalogat(italokNaponta, i);
                NapiItalListatRendez(adottNapiItalok);
                osszesItalNev = KetListatOsszefuttat(osszesItalNev, adottNapiItalok);
            }
            return IsmetlodoItalokKiszurese(osszesItalNev);
        }

        //int[] EladottMennyisegek(string[,] italokNaponta, string[] italok)
        //Megadja, hogy az egyes italokból ténylegesen hány eladás történt.
        static int[] EladottMennyisegek(string[,] italokNaponta, string[] italok)
        {
            int[] eladottMennyisegek = new int[italok.Length];
            for (int i = 0; i < italokNaponta.GetLength(0); i++)
            {
                for (int j = 0; j < italokNaponta.GetLength(1); j++)
                {
                    int k = 0;
                    while (k < italok.Length && italokNaponta[i, j] != italok[k])
                    {
                        k++;
                    }
                    if (k < italok.Length)
                    {
                        eladottMennyisegek[k]++;
                    }
                }
            }
            return eladottMennyisegek;
        }
    }
}
