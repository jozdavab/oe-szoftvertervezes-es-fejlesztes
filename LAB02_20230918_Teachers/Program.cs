namespace LAB02_20230918_Teachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Practice

            //Rövidzár kiértékelés gyakorlás
            Console.WriteLine((3 < 4 || false) && (false || true));     //TRUE
            Console.WriteLine(!true && (!true || 100 != 5 >> 2));       //FALSE
            Console.WriteLine(!!!!!!false || true);                     //TRUE
            Console.WriteLine(false && (5 > 1 * 1 || 7 - 10 > -100) && (!!!!!!false || ((3 < 4 || false)) && (false || true))); //FALSE
            #endregion

            #region NestedIF

            //Köszöntő program.
            Console.WriteLine("Do you speak spanish? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")     //Kis nagy betűk közötti külömbség miatt. Később tanulunk helyette segéd .toLower() függvényt amivel szebben megoldható.
            {
                //A felhasználó igennen válaszolt, köszöntsük az adott nyelven.
                Console.WriteLine("Hola!");
            }
            else  //Vegyük észre, hogy nem csak N és n esetében lépünk ide, hanem bármilyen esetben ami nem Y vagy y.
            {
                Console.WriteLine("Do you speak german? Y/N");
                answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    //A felhasználó igennen válaszolt, köszöntsük az adott nyelven.
                    Console.WriteLine("Guten tag!");
                }
                else //Vegyük észre, hogy nem csak N és n esetében lépünk ide, hanem bármilyen esetben ami nem Y vagy y.
                {
                    Console.WriteLine("Do you speak italian? Y/N");
                    answer = Console.ReadLine();
                    if (answer == "Y" || answer == "y")
                    {
                        //A felhasználó igennen válaszolt, köszöntsük az adott nyelven.
                        Console.WriteLine("Bella ciao!");
                    }
                    else //Vegyük észre, hogy nem csak N és n esetében lépünk ide, hanem bármilyen esetben ami nem Y vagy y.
                    {
                        //A felhasználó semmilyen nyelven nem beszél, köszöntsük egy univerzális jellel.
                        Console.WriteLine("<3");
                    }
                }
            }
            #endregion

            #region DoWhile

            //Program amely addig fut amíg a felhasználó nem ad meg @ jelet.
            //Elöltesztelő ciklus. Ha a belépési feltétel igaz, végrehajtja a ciklusmagban szereplő utasításokat. Majd ismétel amíg a feltétel igaz.
            Console.Write("Give char:");
            char symbolWhile = char.Parse(Console.ReadLine());
            while (symbolWhile != '@')
            {
                Console.Write("Give char:");
                symbolWhile = char.Parse(Console.ReadLine());
            }
            Console.WriteLine("@ found!");

            //Program amely addig fut amíg a felhasználó nem ad meg @ jelet.
            //Hátultesztelő ciklus. Végrehajtja a ciklusmagban szereplő utasításokat, majd megnézi hogy teljesül e a ciklusbanmaradási feltétel. Majd ismétel amíg a feltétel igaz.
            char symbolDo;
            do
            {
                Console.Write("Give char:");
                symbolDo = char.Parse(Console.ReadLine());
            } while (symbolDo != '@');
            Console.WriteLine("@ found!");
            #endregion

            #region GuessingGame

            //Program ami generál egy random számot, amit a felhasználónak ki kell találnia.
            Random rnd = new Random();      //Fontos hogy hol hozzuk létre. Ne legyen a ciklusban, mert akkor többször létrejön a példány.
            int min = 0, max = 100;
            int secretnumber = rnd.Next(min, max + 1);
            int guess;
            int counter = 0;
            do
            {
                Console.Write($"Take a guess between {min} and {max}: ");
                guess = int.Parse(Console.ReadLine());
                Console.Clear();
                if (guess < secretnumber)
                {
                    Console.WriteLine($"{guess} is too low,try again");
                }
                else if (guess > secretnumber)
                {
                    Console.WriteLine($"{guess} is too high, try again!");
                }
                counter++;
            } while (guess != secretnumber);
            Console.WriteLine($"Success, on the {counter} try.");
            #endregion

            #region factorial

            //Faktoriális számoló program.
            Console.Write("Give number:");
            int targetNumber = int.Parse(Console.ReadLine());
            int factorialNumber = 1;
            counter = 1;
            while (counter <= targetNumber)
            {
                /*
                 factorialNumber = factorialNumber*counter;
                 counter = counter +1;
                 */
                factorialNumber *= counter++;       //Rövidebb szintaxis
            }
            Console.WriteLine($"The factorial of {targetNumber} is: {factorialNumber}");
            #endregion

            #region Console

            //Program amely egy karaktert "reptet" végig a konzol elejétől a végéig.
            Console.Write("Give character to be flown:");
            char character = Console.ReadKey().KeyChar;     //Alternatíva char.Parse(Console.ReadLine()) helyett

            int x = 0;

            Console.ForegroundColor = ConsoleColor.Green;   //Karakter színek állítása.
            while (x < Console.WindowWidth)
            {
                Console.Clear();                //Letöröljük az előző jelet    
                Console.CursorLeft = x++;       //Beállítjuk a kurzor pozíciót
                Console.Write(character);       //Karaktert írunk a kurzur pozíció helyére
                Thread.Sleep(100);              //Várunk egy kicsit, hogy szemmel követhető legyen
            }
            #endregion
        }
    }
}