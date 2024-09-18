using System;

namespace LAB08_20231030_Teachers
{
    public class Triangle
    {
        //----------------------------------------FIELDS || MEZŐK

        //Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle amit az összes példány használni tud
        //Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        //Readonly mivel létrehozás után nem akarjuk módosítani.
        private static readonly Random rnd = new Random();

        //Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle amit az összes példány használni tud
        //Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        //Minden konstruktorban növeljük 1-el, így pontosan tudjuk, hány háromszög jött létre összesen.
        private static int TriangleCounter = 0;

        //Ha nem írok láthatóságot, akkor az alapértelmezett lesz, ami private.
        //Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        //Mivel nincsen static kulcsszó, az adott példányhoz fognak tartozni, minden egyes háromszögnek lesz saját a, b, c értéke.
        double a, b, c;


        //----------------------------------------CTOR ||KONSTRUKTOROK

        //Nulla paraméteres konstruktor. A konstruktor meghívódik minden alkalommal, amikor egy új példányt hozunk létre az osztályból.
        public Triangle()
        {
            //Mivel nem kaptunk paramétereket a,b,c hez, állítsuk be az értékeiket randomizált módon.
            do
            {
                a = rnd.Next(1, 101);
                b = rnd.Next(1, 101);
                c = rnd.Next(1, 101);
            } while (!IsValid());
            TriangleCounter++;
        }

        //Egy paraméteres konstruktor, egyenlő oldalú háromszöget csinál
        public Triangle(double side)
        {
            a = side;
            b = side;
            c = side;
            TriangleCounter++;
        }

        //Két paraméteres konstruktor, egyenlő szárú háromszöget csinál
        public Triangle(double first, double second)
        {
            a = first;
            b = second;
            c = second;
            TriangleCounter++;
        }

        //Három paraméteres konstruktor, tetszőleges háromszöget csinál
        public Triangle(double a, double b, double c)
        {
            //Mivel a bejövő paraméter neve azonos az osztály mezőinek nevével, szükséges valahogy megkülönböztetni őket
            //A this. kulcsszóval az osztály adattagjára referálok
            //A this kulcsszó nélkül a legközelebb deklarált változóra referálok (a paraméterként bejövő a,b,c re)
            this.a = a;
            this.b = b;
            this.c = c;
            TriangleCounter++;
        }

        //----------------------------------------METHODS || METÓDUSOK

        //Ez a metódus egy bool értéket ad vissza, amely megmondja, hogy a háromszög érvényes-e.
        //Privát a láthatósága, mivel csak az osztályon belül szeretnénk használni
        private bool IsValid()
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        //Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk.
        //Visszaadja a háromszög kerületét.
        public double Disctrict()
        {
            return a + b + c;
        }

        //Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk.
        //Visszaadja a háromszög területét.
        public double Area()
        {
            double s = Disctrict() / 2;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));      //Heron képlet
        }

        //Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk. SZTF-2-n majd tanulunk rá más megoldást.
        //Megjeleníti a háromszög legfontosabb adatait.
        public string ShowMe()
        {
            return $"A:{a} B:{b} C:{c} Disctrict: {Disctrict()} Area: {Area()}";
        }

        //Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk.
        //Visszaadja az eddig előállított háromszöget számát
        //Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle, és Triangle.GetTriangleCount() formában érhető el.
        //Mivel statikus metódus, nem tudja használni az osztály nem statikus mezőit, így nem fér hozzá az a, b, c értékekhez.
        public static int GetTriangleCount()
        {    
            return TriangleCounter;
        }
    }
}
