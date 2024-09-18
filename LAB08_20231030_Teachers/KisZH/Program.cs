using System;

namespace KisZH
{
    public class Program
    {
        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
        static void Main(string[] args)
        {
            //A csoport elméleti kérdésére a válasz:
            //  A rosszul felépített elágazások miatt a 3 as szám nem számolódik pozitív számnak.
            Console.WriteLine("Give word");
            string word = Console.ReadLine();
            Console.WriteLine("Is palindrome:" + Task5A(word));

            //B csoport elméleti kérdésére a válasz:
            //  A for ciklusban 10 alkalommal is példányosítva lesz a Random generátor.
            Console.WriteLine("Give email");
            string email = Console.ReadLine();
            Console.WriteLine("Is valid email:" + Task5B(email));

            Console.ReadKey();
        }

        /*
         A Palindrom egy olyan szó, vagy szókapcsolat, amely visszafelé olvasva is ugyanaz.
            Írjon egy statikus függvényt, melynek feladata palindromvizsgálat lesz.
            A függvény visszatérési értéke logikai, bemeneti paramétere pedig szöveg legyen.
            A függvény akkor adjon vissza igaz értéket, ha a bemenetül kapott szöveg palindrom!
            A függvény ne tegyen különbséget kis és nagy betűk között, ne vegye figyelembe az esetleges szóközöket.
            A main metódusban tesztelje a függvény működését    
         */
        static bool Task5A(string input)
        {
            input = RemoveWhiteSpace(input).ToLower();
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        //Erre lehetne használni .remove ot is, egyszerűbben, szebben
        //De meg akartam mutatni hogyan működne algoritmikusan.
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

        /*
         Írjon egy statikus függvényt, melynek feladata emailcím ellenőrzés lesz.
            A függvény visszatérési értéke logikai, bemeneti paramétere pedig szöveg legyen.
            Érvényesség szabályai:
            • A címben pontosan 1 db ’@’ (kukac) szerepel
            • Nem szerepelhet benne két pont közvetlenül egymás mellett
            • ’@’ előtti rész:
                • Legfeljebb 64 karakter hosszú
                • Első és utolsó karaktere nem lehet ’.’ (pont)
            • ’@’ utáni rész:
                • Legfeljebb 255 karakter hosszú
                • csak számok, betűk, illetve ’.’ (pont) és ’-’ kötőjel alkothatja
                • ’.’ és ’-’ nem szerepelhet az első és utolsó helyen.    
         */
        static bool Task5B(string input)
        {
            string[] parts = input.Split('@');

            //Kukac ellenőrzés
            if (parts.Length != 2)
            {
                return false;
            }

            string firstPart = parts[0];    //a firstPart változó csak az olvashatóság javítása miatt van
            string secondPart = parts[1];   //a secondPart változó csak az olvashatóság javítása miatt van

            //Hossz ellenőrzés
            if (firstPart.Length > 64 || secondPart.Length > 255)
            {
                return false;
            }

            //.. ellenőrzés
            if (firstPart.Contains("..") || secondPart.Contains(".."))
            {
                return false;
            }

            //Első rész első és utolsó karaktere nem lehet .
            if (firstPart[0] == '.' || firstPart[firstPart.Length - 1] == '.')
            {
                return false;
            }

            for (int i = 0; i < secondPart.Length; i++)
            {
                if (!char.IsLetterOrDigit(secondPart[i]))
                {
                    if (secondPart[i] != '.' || secondPart[i] != '-')
                    {
                        //. és pont nem lehet az első és utolsó karakter
                        if (i == 0 || i == secondPart.Length - 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        //Csak számok betűk, illetve . és - alkothatja.
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
