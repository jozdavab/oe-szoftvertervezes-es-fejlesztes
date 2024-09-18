using System;
using System.Text;

namespace String
{
    //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
    public class Program
    {
        static readonly Random rnd = new Random();

        //Érdekesség: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#string-escape-sequences
        static void Main(string[] args)
        {
            #region Practice
            string str1 = "It's";
            string str2 = "Wednesday";
            string str3 = "my dudes";
            string str4 = str1 + " " + str2 + " " + str3;

            //Olvasásnál tömbként indexelhetőek a string változók karakterei
            Console.WriteLine(str1[2]);

            //String szétválasztása rész stringekké, ' ' jel alapján
            string[] splitted = str4.Split(' ');
            Console.WriteLine(splitted[2]); //Második rész string kiíratása

            //Karakter beolvasása a konzolról
            char example = Console.ReadKey().KeyChar;
            //Beépített segédfüggvény szám és karakter különböztetéséhez.
            Console.WriteLine("Is letter or digit: " + char.IsLetterOrDigit(example));

            //Részsorozat keresése - IndexOf
            int row;
            string exampleString = "These are different characters in a string";
            row = exampleString.IndexOf("characters");
            Console.WriteLine(row);
            row = exampleString.IndexOf("in");
            Console.WriteLine(row);
            row = exampleString.IndexOf("ez nincs benne");
            Console.WriteLine(row);

            //String rész stringjének kinyerése.
            string ss1, ss2;
            ss1 = "Hello, World";
            ss2 = ss1.Substring(7, 5); // Kezdő index: 0
            Console.WriteLine(ss2);

            //String részeinek kicserélése.
            ss1 = ss1.Replace(ss2, "user!"); //ss1 ben felülírjuk ss2 által mutatott szöveg részt, "user!" el
            Console.WriteLine(ss1);
            #endregion


            #region StringBuilder

            string simpleString = "";
            for (int i = 0; i < 2; i++)
            {
                simpleString += ":) ";  //String immutable tulajdonság miatt, mindig új string kreálódik.
            }
            Console.WriteLine(simpleString);

            //String összefűzéshez optimális StringBuildert használnunk.
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                stringBuilder.Append(":) ");
            }
            Console.WriteLine(stringBuilder.ToString());

            #endregion

            #region Neptun

            //Neptun kód generáló feladat
            string neptun = GenerateNeptun();
            Console.WriteLine($"I generated the {neptun} neptuncode for you");
            #endregion

            #region vowels
            Console.WriteLine("Give word");
            string word = Console.ReadLine();

            //Számoljuk meg hány magánhangzó volt a szóban
            int number = Vowels(word);

            Console.WriteLine($"Number of vowels in {word} : {number}");
            #endregion

            #region whiteSpace
            Console.WriteLine("Give word");
            word = Console.ReadLine();
            string formatted = RemoveWhiteSpace(word);
            Console.WriteLine($"Word without whitespaces:{formatted}");
            #endregion

            Console.ReadKey();
        }

        //6 jegyű neptunkód, random betűkkel vagy számokkal
        static string GenerateNeptun()
        {
            string neptun = "";

            for (int i = 0; i < 6; i++)
            {
                if (rnd.Next(2) == 0)
                {
                    neptun += rnd.Next(0, 10);
                }
                else
                {
                    neptun += (char)rnd.Next('A', 'Z' + 1); //CHAR <-> int ASCII szerint.
                }
            }
            return neptun;
        }

        static bool IsVowel(char character)
        {
            char[] vowels = { 'a', 'á', 'e', 'é', 'i', 'í', 'o', 'ó', 'ö', 'ő', 'u', 'ú', 'ü', 'ű' };

            character = char.ToLower(character); //Kisnagybetűs eltérések egyszerűsítése miatt.

            //Eldöntés tétel
            int i = 0;
            while (i < vowels.Length && vowels[i] != character)
            {
                i++;
            }
            return i < vowels.Length;
        }

        static int Vowels(string word)
        {
            int counter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    counter++;
                }
            }
            return counter;
        }

        //Egyesével eltávolítja az összes szóközt egy stringből
        static string RemoveWhiteSpace(string input)
        {
            string output = input;

            do
            {
                int placeofWhitespace = output.IndexOf(" ");

                if (placeofWhitespace != -1)
                {
                    output = output.Substring(0, placeofWhitespace) + output.Substring(placeofWhitespace + 1, output.Length - placeofWhitespace - 1);
                }

            } while (output.Contains(" "));

            return output;
        }
    }
}
