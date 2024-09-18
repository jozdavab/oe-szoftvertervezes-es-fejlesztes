using System;

namespace LAB03_20230925_Teachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Arrays

            int variable = 10;
            int[] exampleArray = new int[10];       //10 méretű intekből álló tömb. Minden helyen az int alapértéke (0) van benne.
            exampleArray[0] = variable;             //0 val indexeljük az első elemet. Értékül adjuk az első elemnek a variable változó által tárolt 10 es értéket.

            Console.WriteLine(exampleArray);        //Így NEM tudjuk kiíratni a tömb elemeit

            //Tömb elemeinek kiíratása ciklus segítségével.
            int index = 0;
            while (index < exampleArray.Length)             //.Length visszaadja a tömbben található elemek számát (jelenesetben 10)
            {
                exampleArray[index] = index;                //Tömb indexedik elemének feltöltése, index értékkel.
                Console.WriteLine(exampleArray[index]);     //írjuk ki a tömb indexedik helyen lévő elemét
                index++;                                    //Index léptetése, hogy végig mehessünk vele a tömbön.
            }

            //For ciklus. Tömb bejáráshoz ideális
            for (int i = 0; i < 10; i++)                    //I ciklusváltozó 0 ról indul, 10-ig (9) megy el, egyesével lép.
            {
                Console.WriteLine($"This is the {i}. iteration");
            }

            //Tömbbejárás egyszerűen
            for (int i = 0; i < exampleArray.Length; i++)   //I ciklusváltozó 0 ról indul, tömbhosszig megy el, egyesével lép.
            {
                Console.WriteLine(exampleArray[i]);
            }

            int[] reversedExampleArray = new int[exampleArray.Length];
            int counter = 0;
            //Tömbbejárás fordítva, reversed tömb feltöltése az előző tömb elemeivel, visszafelé
            for (int i = exampleArray.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(exampleArray[i]);
                reversedExampleArray[counter++] = exampleArray[i];
            }

            ;
            #endregion

            #region Tételek

            //Hozzuk létre egy 50-150 közötti random méretű tömböt és töltsük fel 0-100 közötti random számokkal.
            Random rnd = new Random();
            int[] array1 = new int[rnd.Next(50, 151)];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = rnd.Next(0, 101);
            }

            //Sorozatszámítás. Mi tömb elemeinek összege, és ezeknek átlaga.
            counter = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                counter += array1[i];
            }
            Console.WriteLine($"sum:{counter}");
            Console.WriteLine($"average:{counter / array1.Length}");

            //Megszámlálás. Hányszor szerepel a 42 a tömbben.
            counter = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] == 42)
                {
                    counter++;
                }
            }
            Console.WriteLine($"Number 42 occured {counter} times");

            //Maximumkiválasztás. Mi a tömb legnagyobb eleme.
            int maxIndex = 0;
            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i] > array1[maxIndex]) maxIndex = i;
            }
            Console.WriteLine($"Max element at: {maxIndex}, with value of: {array1[maxIndex]}");

            #endregion

            #region PasswordManager
            //Írjunk egy programot ami eltárol N felhasználónév-jelszó párost, majd megpróblja bejelentkeztetni a felhasználót.

            //Kérjük be hány jelszót akarunk eltárolni
            Console.Write("Number of logins:");
            string[] names = new string[int.Parse(Console.ReadLine())];
            string[] pswds = new string[names.Length];

            //Kérjük be a név-jelszó párosokat
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Give name");
                names[i] = Console.ReadLine();
                Console.WriteLine("Give pswd");
                pswds[i] = Console.ReadLine();
            }
            Console.WriteLine("Saved");


            //Próbáljunk meg loginolni
            Console.WriteLine("Please log in!\nGive Name");
            string nameGuess = Console.ReadLine();

            //Eldöntés tétel. Van e ilyen nevű felhasználó a tömbben.
            bool isValidName;
            int j = 0;
            while (j < names.Length && names[j] != nameGuess)
            {
                j++;
            }
            isValidName = j < names.Length;

            //Kérjük be a jelszót
            Console.WriteLine("Password:");
            string pswdGuess = Console.ReadLine();

            //Jelszó és név vizsgálat
            if (isValidName)
            {
                if (pswds[j] == pswdGuess)
                {
                    Console.WriteLine("Successful login");
                }
                else
                {
                    //Tudjuk hogy a jelszó a rossz, és nem a név, de biztonsági okokból nem tájékoztatjuk erről a belépőt
                    Console.WriteLine("Name or password is invalid");
                }
            }
            else
            {
                //Tudjuk hogy a név a rossz, és nem a jelszó, de biztonsági okokból nem tájékoztatjuk erről a belépőt
                Console.WriteLine("Name or password is invalid");
            }

            #endregion

            #region Szókirakó játék

            //Program ami összekever szavakat egy mondatban, majd a felhasználóval összerakatja jó sorrendbe.

            string[] Words = { "Ezeket", "most", "jól", "összekeverem", "!" };
            string[] ShuffledWords = new string[Words.Length];

            //Egy megoldás keverésre. Vegyük észre hogy a while feltétel miatt a random generálás sokszor is újrafuthat!
            for (int i = 0; i < Words.Length; i++)
            {
                int rndLocation;
                do
                {
                    rndLocation = rnd.Next(0, ShuffledWords.Length);
                } while (ShuffledWords[rndLocation] != null);   //Addig generáljuk újra a random számot amíg üres helyre nem mutat. Ismétlődésszűrés
                ShuffledWords[rndLocation] = Words[i];
            }

            bool wantsToQuit = false;
            do
            {
                //Kiírjatjuk a megkevert szavakat
                for (int i = 0; i < ShuffledWords.Length; i++)
                {
                    Console.WriteLine(i + ShuffledWords[i]);
                }

                //Felhasználó akar e cserélni.
                Console.WriteLine("You want to swap some of them? y/n");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine($"Give index between 0 and {ShuffledWords.Length}");
                    int idx1 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Give index between 0 and {ShuffledWords.Length} except {idx1}");
                    int idx2 = int.Parse(Console.ReadLine());

                    //Értelmetlen eset
                    if (idx1 == idx2)
                    {
                        Console.WriteLine("You want to swap the same elements");
                    }
                    //Túl és alul indexelés ellenőrzés
                    else if (idx1 >= 0 && idx2 >= 0 && idx1 < ShuffledWords.Length && idx2 < ShuffledWords.Length)
                    {
                        //Segédváltozó használata a cseréhez.
                        string swap = ShuffledWords[idx1];
                        ShuffledWords[idx1] = ShuffledWords[idx2];
                        ShuffledWords[idx2] = swap;
                        Console.WriteLine("Succesful swap");
                    }
                    else
                    {
                        Console.WriteLine("You want to swap wrong elements");
                    }

                }
                else
                {
                    //Ha nem akar cserélni, véget ér a program.
                    wantsToQuit = true;
                }

            } while (!wantsToQuit);

            Console.WriteLine("Task over");

            #endregion
        }
    }
}
