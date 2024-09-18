using System.IO;

namespace LAB12_20231127_Teachers
{
    public class Album
    {
        //--------------------------- MEZŐK || FIELDS ---------------------------

        /*
         *  Tárolja az album előadóját és címét (string), az adathordozó típusát, illetve az albumon szereplő zeneszámokat (tömb).
         */
        private string eloado;
        private string cim;
        private Adathordozo adathordozoTipus;
        private Zeneszam[] zeneszamok;

        //--------------------------- TULAJDONSÁGOK || PROPERTIES ---------------

        //--------------------------- KONSTRUKTOROK || CONSTRUCTORS -------------

        /*
         *  Készítsen egy konstruktort, amelynek paraméterei az album előadója és címe, és egy szöveges fájl elérési
         *  útvonala. A fájl minden sorában a fenti formátum szerinti zeneszám adatok találhatók. A konstruktor
         *  ezt a fájlt megnyitva és feldolgozva hozza létre és töltse fel az albumhoz tartozó felvételeket. Használja a
         *  Feldolgozas metódust.        
         */
        public Album(string eloado, string cim, string utvonal)
        {
            this.eloado = eloado;
            this.cim = cim;

            StreamReader sr = new StreamReader(utvonal);
            int sorSzam = 0;
            zeneszamok = new Zeneszam[sorSzam];
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                Zeneszam zeneszam = Zeneszam.Feldolgozas(sor);
                FelveteltHozzaad(zeneszam, sorSzam++);
            }
            sr.Close();
        }

        //--------------------------- METÓDUSOK || METHODS ---------------------

        /*
         *  A FelveteltHozzaad nevű privát metódus egy Zeneszam példányt és egy indexet (int) kap paraméterként,
         *  majd elhelyezi a zeneszámot tömbben az adott indexre
         */
        private void FelveteltHozzaad(Zeneszam zeneszam, int index)
        {
            if (index >= zeneszamok.Length)
            {
                Zeneszam[] ujzeneSzamok = new Zeneszam[zeneszamok.Length + 1];
                for (int i = 0; i < zeneszamok.Length; i++)
                {
                    ujzeneSzamok[i] = zeneszamok[i];
                }
                ujzeneSzamok[index] = zeneszam;
                this.zeneszamok = ujzeneSzamok;
            }
            else
            {
                zeneszamok[index] = zeneszam;
            }
        }

        /*
         *  Hozzon létre egy LegrovidebbFelvetel nevű privát metódust, amely meghatározza és visszaadja a legrövidebb zeneszám címét.
         */
        private string LegrovidebbFelvetel()
        {
            int mini = 0;
            for (int i = 1; i < zeneszamok.Length; i++)
            {
                if (zeneszamok[i].IdoTartam < zeneszamok[mini].IdoTartam)
                {
                    mini = i;
                }
            }
            return zeneszamok[mini].Cim;
        }

        /*
         * Hozzon létre egy JatekidoOsszesites(int) szignatúrájú privát metódust, amely meghatározza a paraméterként
         *  megadott időtartamnál hosszabb zeneszámok összesített lejátszási idejét.
         */
        private int JatekIdoOsszesites(int kuszob)
        {
            int osszIdo = 0;
            foreach (Zeneszam zene in zeneszamok)
            {
                if (zene.IdoTartam > kuszob)
                {
                    osszIdo += zene.IdoTartam;
                }
            }

            return osszIdo;
        }

        /*
         *  Hozzon létre egy VanElegZeneszam(string, int) szignatúrájú privát metódust, amely megadja, hogy az első
         *  paraméterként megadott szerzőnek van-e legalább a második paraméter által megadott darabszámú zeneszáma az albumon. 
         */
        private bool VanElegZeneszam(string szerzo, int kuszob)
        {
            int db = 0;
            foreach (Zeneszam zene in zeneszamok)
            {
                if (zene.Szerzo.Contains(szerzo))
                {
                    db++;
                }
            }

            return db >= kuszob;
        }

        /*
         *  Készítsen egy Kivalogat(string) szignatúrájú privát metódust, amely az albumon lévő zeneszámok közül
         *  kiválogatja azokat, amelynek a szerzői között szerepel a paraméterként megadott szerző. Az előállított
         *  tömb ne tartalmazzon üres elemeket, és ez legyen a függvény visszatérési értéke. (5 pont)
         */
        private Zeneszam[] Kivalogat(string szerzo)
        {
            int szamlalo = 0;
            foreach (Zeneszam zene in zeneszamok)
            {
                if (zene.Szerzo.Contains(szerzo))
                {
                    szamlalo++;
                }
            }

            Zeneszam[] szerzoZeneszamai = new Zeneszam[szamlalo];
            szamlalo = 0;
            foreach (Zeneszam zene in zeneszamok)
            {
                if (zene.Szerzo.Contains(szerzo))
                {
                    szerzoZeneszamai[szamlalo++] = zene;
                }
            }

            return szerzoZeneszamai;
        }

        /*  
         *  Készítsen egy publikus Lekerdez(string) nevű metódust.A metódus elkészíti és visszaadja a paraméterként
         *  megadott szerzőnek megfelelő számok listáját egy formázott stringként.
         */
        public string Lekerdez(string szerzo)
        {
            Zeneszam[] szerzoZeneszamai = Kivalogat(szerzo);
            string kimenet = $"{eloado} - {cim} (by {szerzo})\n\n";

            int szamlalo = 1;
            foreach (Zeneszam zene in szerzoZeneszamai)
            {
                kimenet += $"{szamlalo++}. {zene.Cim} ({zene.Szerzo}) - {zene.FormazottIdo()}\n";
            }

            return kimenet;
        }
    }
}
