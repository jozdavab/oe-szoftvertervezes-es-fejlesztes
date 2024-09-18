using System;

namespace LAB12_20231127_Teachers
{
    public class Zeneszam
    {
        //--------------------------- MEZŐK || FIELDS ---------------------------

        /*
         *  Tárolja privát mezőkben a zeneszám címét és szerzőjét (string), és időtartamát másodpercben (int).
         */

        private string cim;
        private string szerzo;
        private int idoTartam;

        //--------------------------- TULAJDONSÁGOK || PROPERTIES ---------------

        /*
         *  A mezők értéke legyen lekérdezhető egy-egy csak olvasható publikus tulajdonságon keresztül. Az időtartam
         *  módosítására legyen lehetőség tulajdonságon keresztül, de az új hossz nem lehet negatív. 
         */

        public string Cim { get => cim; }
        public string Szerzo { get { return szerzo; } }
        public int IdoTartam
        {
            get
            {
                return idoTartam;
            }
            set
            {
                if (idoTartam >= 0)
                {
                    idoTartam = value;
                }

            }
        }

        //--------------------------- KONSTRUKTOROK || CONSTRUCTORS -------------

        /*
         *  Az osztály rendelkezzen egy három paramétert fogadó konstruktorral,
         *  amely segítségével az adattagok kezdőértéket kapnak.
         */
        public Zeneszam(string cim, string szerzo, int idoTartam)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            IdoTartam = idoTartam;
        }

        //--------------------------- METÓDUSOK || METHODS ---------------------

        /*
         *  Készítsen egy statikus Feldolgozas nevű publikus metódust. Ez egy paraméterként kapott karakterlánc
         *  alapján előállít és visszaad egy Zeneszam példányt. A karakterlánc formátuma az alábbi
         *  Until It Sleeps;Hetfield, Ulrich;270
         */
        public static Zeneszam Feldolgozas(string karakterLanc)
        {
            string[] adatok = karakterLanc.Split(';');
            return new Zeneszam(adatok[0], adatok[1], int.Parse(adatok[2]));
        }

        /*
         *  Készítsen egy publikus FormazottIdo nevű függvényt,
         *  amely a zeneszám hosszát MM:SS formátumú stringként adja vissza (perc:másodperc).
         */
        public string FormazottIdo()
        {
            return $"{idoTartam / 60}:{idoTartam % 60}";
        }
    }
}
