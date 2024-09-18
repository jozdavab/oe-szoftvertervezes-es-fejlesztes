using System;

namespace LAB08_20231030_Teachers
{
    public class Dartboard
    {

        //----------------------------------------FIELDS || MEZŐK

        //Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle amit az összes példány használni tud
        //Readonly mivel létrehozás után nem akarjuk módosítani.
        static readonly Random rnd = new Random();

        //Ha nem írok láthatóságot, akkor az alapértelmezett lesz, ami private.
        //Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        //Mivel nincsen static kulcsszó, az adott példányhoz fognak tartozni, minden egyes Dartboardnak lesz saját centere és radiusa.
        //Mivel csak a kontstruktorban, egyszer állítjuk be az értékeiket, utána csak olvasva vannak, ezért readonly kulcsszóval látjuk el őket.
        readonly Coordinate center;         //A Coordinate egy saját típus, hisz mi hoztuk létre ezt az osztályt.
        readonly double radius;

        //----------------------------------------CTOR ||KONSTRUKTOROK

        //3 paraméteres konstruktor, amely X Y koordinátákból létrehoz egy Coordinate osztályt, és beállítja a radius mező értékét
        public Dartboard(double X, double Y, double radius)
        {
            //Ez nem jó!! center nincsen példányosítva, ezért még null. Null érték nem rendelkezik X és Y mezővel.
            //center.X = X;
            //center.Y = Y;

            center = new Coordinate(); //Létrehozom a Coordinate példányt.
            //Mostmár beállítható az X és Y mező.
            center.X = X;
            center.Y = Y;

            this.radius = radius;
        }

        //1 paraméteres konstruktor, amely randomizál egy X Y koordinátát, és beállítja a radius mező értékét
        public Dartboard(double radius)
        {
            //Ezt a szintaxist is tudjuk használni, hogy létrehozáskor beállítsuk a mezőket.
            center = new Coordinate()
            {
                X = rnd.Next(1, 21),
                Y = rnd.Next(1, 21)
            };

            this.radius = radius;
        }

        //----------------------------------------METHODS || METÓDUSOK

        //Eldönti, hogy egy adott koordináta, a dartboardon belül van-e.
        public bool IsInside(Coordinate target)
        {
            double distance = DstBetween(target);
            return (radius > distance);
        }

        //Kiszámolja, hogy a mi középpontunk és a másik koordináta között mekkora a távolság.
        public double DstBetween(Coordinate other)
        {
            return Math.Sqrt(Math.Pow(center.X - other.X, 2) + Math.Pow(center.Y - other.Y, 2));
        }

        //Pontozza a dobást, a középponthoz közelebbi dobásokat jobban pontozza.
        public int Score(Coordinate target)
        {
            double dst = DstBetween(target);

            if (dst == 0)           //Telitalálat
            {
                return 5;
            }
            else if (dst < radius)  //Eltaláltuk a táblát valahol
            {
                return 3;
            }
            else if (dst == radius) //Tábla szélét találtuk el
            {
                return 1;
            }
            else                    //Semmit nem találtunk el
            {
                return 0;
            }
        }
    }
}
