namespace LAB01_20230911_Teachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // region - endregion blokkok miatt áttekinthetőbb a kód. Oldalt a kis +- jelekkel lehet kinyitni és becsukni őket.

            #region Integers | Declaration | Inicialization | Operations

            int num1;                       // Változó deklarálása. Elől a típusa szerepel (int), hátul a neve, amivel hivatkozhatunk rá (num1);
            num1 = 1;                       // Változó inicializálása.
            Console.WriteLine(num1);        // Változó értékének kiírása a konzolra (1). "cw tab tab"

            int num2 = 2;                   // Deklarálás és inicializálás összevonható

            int num3,num4, num5;            // Több változó deklarálása egyszerre
            int num6 = 6, num7 = 7;         // Több változó deklarálása és inicializálása egyszerre

            num3 = num2 + num1;             // Értékadás változónak művelettel.
            Console.WriteLine(num3);        // Változó értékének kiírása a konzolra (3)

            int c = 2014;
            //Inkrementálás 4 különböző módon
            c = c + 1;                      // Változó inkrementálása
            c += 1;                         // Változó inkrementálása
            c++;                            // Változó inkrementálása
            ++c;                            // Változó inkrementálása
            Console.WriteLine(c);           // Változó értékének kiírása a konzolra (2018)

            //Fontos különbség!
            Console.WriteLine(c++);         // Változó értékének kiírása a konzolra (2018), majd változó inkrementálása 
            Console.WriteLine(++c);         // Változó inkrementálása, majd változó értékének kiírása a konzolra (2020)

            Console.WriteLine(c + 1);       // Művelet kiírása konzolra (2020 + 1).
            Console.WriteLine(c);           // Mivel előbb az értéket nem tároltuk, C változatlan (2020).

            #endregion

            #region Bool | Logical Operators

            bool b1 = true;                 // Logikai típus
            Console.WriteLine(b1);          // Változó értékének kiírása a konzolra (true);    
            b1 = !b1;                       // Változó negálása, átbillentése.
            Console.WriteLine(b1);          // Változó értékének kiírása a konzolra (false);

            bool result1 = false || true;                       // VAGY logikai művelet. (true)
            Console.WriteLine(result1);
            bool result2 = false && true;                       // ÉS logikai művelet.   (false)
            Console.WriteLine(result2);
            bool result3 = (!false && result2) || result1;      // Kombinált műveletek.  (true)
            Console.WriteLine(result3);

            #endregion

            #region String | Char | Type conversion | Formatting

            string elso = "This sentence";  // A szöveg "" ok között szerepel.
            string masodik = "finishes";
            //char c = '!';                 // Fordítási hiba, c már deklarálva van.
            char jel = '!';                 // A karakter '' között szerepel.
            string mondat = elso + masodik + jel;
            Console.WriteLine(mondat);
            Console.WriteLine(elso + " " + masodik + jel);

            Console.Write("Type your name:\t");     // Escape karakterek: https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions
            string userInput = Console.ReadLine();  // Szöveget olvas a konzolról Enter lenyomásáig
            Console.WriteLine("Hello " + userInput);

            Console.Write("Give birthdate:\t");
            int userInputNum = int.Parse(Console.ReadLine());   // Type conversion! Szöveget kértünk be, számként tárolunk
            int age = 2023 - userInputNum;

            //3 alternatív módszer kiíratáshoz
            Console.WriteLine("Hi " + userInput + "! You are " + age + " yrs old in 2023.");
            Console.WriteLine("Hi {0}! You are {1} yrs old in 2023.", userInput, age);
            Console.WriteLine($"Hi {userInput}! You are {age} yrs old in 2023.");

            #endregion

            #region Double | Typeloss | Modulo | Math

            double d1 = 1.01;
            int i1 = (int)d1;       // Explicit casting. Nagyobb típus a kisebbe. Értékvesztés történhet!
            double d2 = i1;         // Implicit casting. Kisebb típus a nagyobba.
            Console.WriteLine(d1);  // Változó értékének kiírása a konzolra (1.01)
            Console.WriteLine(i1);  // Változó értékének kiírása a konzolra (1)
            Console.WriteLine(d2);  // Változó értékének kiírása a konzolra (1)

            //Fahrenheit Calculator. [°F] = [°C] * 9 / 5 + 32
            Console.Write("Give temperature in °C:\t");
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = celsius * 9 / 5 + 32;
            double fahrenheitBad = celsius * (9 / 5) + 32;    // 9/5 nél int/int osztás van, aminek az eredménye is int, ezért más eredményt kapnánk.
            Console.WriteLine($"Temperature in F: {fahrenheit} °F");
            Console.WriteLine($"Temperature in F (WRONG): {fahrenheitBad} °F");

            //Modulo and Math
            Console.Write("Give a number:\t");
            int number = int.Parse(Console.ReadLine());

            int modNumber = number % 2;                     // Maradékos osztás
            Console.WriteLine($"Your number % 2 = {modNumber}");

            //Négyzetszám eldöntő program
            int sqrt = (int)Math.Sqrt(number);              // Értékvesztés konverzió miatt. Math.sqrt double-t ad vissza, de egésszé lesz kasztolva
            bool isSquareNumber = sqrt * sqrt == number;    // Ha visszakapjuk az eredeti számot, akkor nem történt érték vesztés, ergo négyzetszám volt.
            Console.WriteLine("Is given number a square number?: " + isSquareNumber);   // Stringet és boolt is össze lehet fűzni a + jellel.

            #endregion

            #region Underflow

            uint unbderflowNum = 0;                         // Unsigned integer. 0 -> 4,294,967,295
            Console.WriteLine(unbderflowNum);
            unbderflowNum -= 1;
            Console.WriteLine(unbderflowNum);

            #endregion

            #region Condition | IF statement

            if (true || Math.Pow(99, 3) % 72 == 4)  //Rövidzárkiértékelés. True után a VAGY miatt a második feltétel nem kerül kiszámolásra.
            {
                Console.WriteLine("We always hit this code.");
            }

            Console.Write("Give first number:\t");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Give second number:\t");
            int secondNumber = int.Parse(Console.ReadLine());

            string op;
            if (firstNumber == secondNumber)    //Belépünk a blokkba, ha a feltétel igaz.
            {
                op = "=";
            }
            else if (firstNumber > secondNumber) //Belépünk a blokkba, ha az előző feltétel hamis, és ez a feltétel igaz.
            {
                op = ">";
            }
            else    //Ha az előzőek egyikénél sem léptünk be a blokkba, akkor itt belépünk.
            {
                op = "<";
            }
            Console.WriteLine($"{firstNumber}{op}{secondNumber}");

            #endregion

            #region Quadratic equation
            Console.Write("Give A:\t");
            int A = int.Parse(Console.ReadLine());
            Console.Write("Give B:\t");
            int B = int.Parse(Console.ReadLine());
            Console.Write("Give C:\t");
            int C = int.Parse(Console.ReadLine());

            int discriminant = B * B - 4 * (A * C);     //Gyök alatti rész.

            if (discriminant < 0)
            {
                Console.WriteLine("Bad values");
            }
            else if (discriminant == 0)
            {
                Console.WriteLine("The X is:" + (-B / 2 * A));
            }
            else
            {
                Console.WriteLine("X1 is: {0}, \nX2 is: {1}", (-B + Math.Sqrt(discriminant)) / (2 * A), (-B - Math.Sqrt(discriminant)) / (2 * A));
            }
            #endregion


            Console.ReadKey(); // Vár egy billentyű leütést. Azért van itt, hogy ne záruljon be egyből a konzol miután lefutott az előtte lévő kód. Új VS esetén CTRL + F5 helyettesíti.
        }
    }
}