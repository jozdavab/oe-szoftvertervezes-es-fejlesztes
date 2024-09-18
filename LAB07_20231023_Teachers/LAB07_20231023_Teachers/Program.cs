using System;

namespace LAB07_20231023_Teachers
{
    //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
    public class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            /*
            Az alkalmazás teszteléséhez hozzon létre egy adott N ≥ 10 feladat tárolására alkalmas kétdimenziós tömböt,
                majd a SubmitJob() segítségével töltse fel véletlenszerűen generált adatokkal.
                A témaszámok véletlen, ABCD - 1 - 2 alakú szavak legyenek, a gépidő egy véletlen[1, 1000]-beli egész,
                a prioritás pedig egy véletlen 0.0 és 1.0 közötti valós szám legyen.
                Ha egy feladatnál az ő témaszámára már van beküldött feladat, 
                írja ki a témaszámhoz tartozó összesített gépidőt (8 pont)
            */
            string[,] dataArray = new string[10, 3];
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                string projectID = "";
                for (int j = 0; j < 4; j++)
                {
                    projectID += rnd.Next('A', 'Z' + 1);
                }
                projectID += "-" + rnd.Next(0, 10) + "-" + rnd.Next(0, 10);
                int time = rnd.Next(1, 1001);
                double priority = rnd.NextDouble();
                if (SubmitJob(dataArray, i, projectID, time, priority))
                {
                    Console.WriteLine("A {0} témaszámra összesen {1} gépidőt igényeltek.", projectID, CountSubmittedJobs(dataArray, projectID));
                }
            }
            /*
                A korábban megírt metódusok alkalmazásával gyűjtse le az 500 - nál nagyobb gépidő igényű témaszámokat,
                    adja meg a(z egyik) maximális gépidőt igénylő témaszámot,
                    rendezze a kétdimenziós tömböt, majd írja ki a képernyőre a tartalmát. (2 pont)
            */
            Console.WriteLine("A tömb:");
            Console.WriteLine(DataArrayToString(dataArray));

            int treshold = 500;
            Console.WriteLine($"A(z) {treshold} nál nagyobb projektek:");
            string[] bigProjectIDs = CollectComplexJobsProjectIDs(dataArray, treshold);
            if (bigProjectIDs.Length > 0)
            {
                for (int i = 0; i < bigProjectIDs.Length; i++)
                {
                    Console.WriteLine(bigProjectIDs[i]);
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen projekt.");
            }

            Console.WriteLine("A maximális gépidőt igénylő témaszám:");
            string maxProjectID = SelectMaximalComplexity(dataArray);
            Console.WriteLine(maxProjectID);

            Console.WriteLine("A rendezett tömb:");
            SortDataArray(dataArray);
            Console.WriteLine(DataArrayToString(dataArray));
        }

        /*
         Eldönti, hogy a projectID témaszámra rögzítettek-e már feladatot a dataArray-ben.
         */
        static bool HasSubmittedProjectID(string[,] dataArray, string projectID)
        {
            int i = 0;
            while (i < dataArray.GetLength(0) && dataArray[i, 0] != projectID)
            {
                i++;
            }
            return i < dataArray.GetLength(0);
        }

        /*
         A dataArray tömb row indexű sorába rögzíti a projectID témaszámú, time gépidő igényű, priority
            prioritású feladatot. Visszatérési értékként adja meg, hogy ilyen témaszámra a mostani beküldést
            megelőzően küldtek-e már be feladatot (lásd HasSubmittedProjectID()).
         */
        static bool SubmitJob(string[,] dataArray, int row, string projectID, int time, double priority)
        {
            bool hasSubmitted = HasSubmittedProjectID(dataArray, projectID);

            dataArray[row, 0] = projectID;
            dataArray[row, 1] = time.ToString();
            dataArray[row, 2] = priority.ToString();
            return hasSubmitted;
        }

        /*
         A paraméterül kapott kétdimenziós tömb alapján egyetlen karakterláncot épít fel a tömb minden
            adatából úgy, hogy annak sorait
            témaszám : gépidő (prioritás)
            formátumnak megfelelően fűzi össze. A megoldáshoz alkalmazza a sorozatszámítás programozási tétel
            elvét.
         */
        static string DataArrayToString(string[,] dataArray)
        {
            string output = "";
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                output += dataArray[i, 0] + " : " + dataArray[i, 1] + " (" + dataArray[i, 2] + ")" + "\n";
            }
            return output;
        }

        /*
         Megadja, hogy a dataArray tömbben lévő feladatok közül a projectID témaszámra összesen mennyi
            gépidőt igényeltek.
        */
        static int CountSubmittedJobs(string[,] dataArray, string projectID)
        {
            int counter = 0;
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                if (dataArray[i, 0] == projectID)
                {
                    counter += int.Parse(dataArray[i, 1]);
                }
            }

            return counter;
        }

        /*
         Egydimenziós tömbbe gyűjti a dataArray-ben lévő feladatok közül a threshold-nál nagyobb gépigényűek projectID-it.
            A visszaadott tömb mérete egyezzen meg annak valódi elemszámával, azaz ne legyenek benne üres elemek.
         */
        static string[] CollectComplexJobsProjectIDs(string[,] dataArray, int threshold)
        {
            int counter = 0;
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                if (int.Parse(dataArray[i, 1]) > threshold)
                {
                    counter++;
                }
            }

            string[] projectIDs = new string[counter];
            counter = 0;
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                if (int.Parse(dataArray[i, 1]) > threshold)
                {
                    projectIDs[counter++] = dataArray[i, 0];
                }
            }

            return projectIDs;
        }

        /*
         Megkeresi és visszaadja a legmagasabb igényelt gépidőhöz tartozó témaszámot.
         */
        static string SelectMaximalComplexity(string[,] dataArray)
        {
            int maxi = 0;
            for (int i = 1; i < dataArray.GetLength(0); i++)
            {
                if (int.Parse(dataArray[i, 1]) > int.Parse(dataArray[maxi, 1]))
                {
                    maxi = i;
                }
            }
            return dataArray[maxi, 0];
        }

        /*
         Az egyes bejegyzések gépidő × prioritás szorzatának nagysága alapján növekvő sorrendbe rendezi a
            paraméterben átadott kétdimenziós tömb sorait. 
            A megoldáshoz alkalmazza valamely előadáson ismertetett rendező algoritmust.
         */
        static void SortDataArray(string[,] dataArray)
        {
            for (int i = 1; i < dataArray.GetLength(0); i++)
            {
                int j = i - 1;

                string[] tmp = { dataArray[i, 0], dataArray[i, 1], dataArray[i, 2] };
                while (j > -1 && Fitness(dataArray[j, 1], dataArray[j, 2]) > Fitness(tmp[1], tmp[2]))
                {
                    dataArray[j + 1, 0] = dataArray[j, 0];
                    dataArray[j + 1, 1] = dataArray[j, 1];
                    dataArray[j + 1, 2] = dataArray[j, 2];
                    j--;
                }
                dataArray[j + 1, 0] = tmp[0];
                dataArray[j + 1, 1] = tmp[1];
                dataArray[j + 1, 2] = tmp[2];
            }
        }

        static double Fitness(string time, string prio)
        {
            return int.Parse(time) * double.Parse(prio);
        }
    }
}
