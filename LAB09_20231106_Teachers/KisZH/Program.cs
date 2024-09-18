using System;

namespace KisZH
{
    public class Program
    {
        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt

        //Teszteléshez hozzon létre a Main metódusban egy 10 elemű tetragon tömböt.
        //Példányosítson a megfelelő tömb indexekre 1-1 tetragont és
        //hívja meg mindegyiken az őt megjelenítő metódust!
        static void Main(string[] args)
        {
            Tetragon[] tetragons = new Tetragon[10];
            for (int i = 0; i < tetragons.Length; i++)
            {
                tetragons[i] = new Tetragon(20, 10);
                tetragons[i].ShowMe();
            }

            Console.ReadKey();
        }

        //Elméleti kérdésre válaszok:

        //A: SayMyName() metódus statikus, így nem éri el a nem statikus "name" mezőt.
        //B: "somebody" változó értéke null, mivel nem lett példányosítva New Person() -al.
        //C: SayMyName() metódus privát, így nem érhető el a Main metódusból.
        //D: PeopleCount mező statikus, így Person.PeopleCount ként tudjuk elérni.
    }
}
