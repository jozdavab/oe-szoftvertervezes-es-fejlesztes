using System;

namespace LAB08_20231030_Teachers
{
    public class Program
    {
        //Solution explorerben jobb klikk a projektre -> Set as Startup Projekt
        static void Main(string[] args)
        {
            #region Triangle

            //Létrehozok egy Triangle típusú, triangleRandom nevű változót, és a 0 paraméteres konstruktor segítségével példányosítom.
            Triangle triangleRandom = new Triangle();

            //Meghívom a háromszög példányon a showme metódust, és kiírom a visszakapott stringet a konzolra.
            Console.WriteLine(triangleRandom.ShowMe());

            //Létrehozok egy Triangle típusú, triangleUser nevű változót, és a 3 paraméteres konstruktor segítségével beállítom az összes oldalát.
            Triangle triangleUser = new Triangle(3, 4, 4);

            //Meghívom a háromszög példányon a showme metódust, és kiírom a visszakapott stringet a konzolra.
            Console.WriteLine(triangleUser.ShowMe());

            //Létrehozok egy 3 elemű, háromszög típusokat tartalmazó tömböt. Alapértelmezetten null értékeket kapnak a tömb elemei.
            Triangle[] triangles = new Triangle[3];

            //Bejárom a tömböt
            for (int i = 0; i < triangles.Length; i++)
            {
                //Minden egyes elemre példányosítok egy új háromszöget, és beleteszem a tömbbe.
                triangles[i] = new Triangle();

                //Minden egyes elemet kiíratok a konzolra.
                Console.WriteLine(triangles[i].ShowMe());

                //Ez nem lenne túl olvasható
                //Console.WriteLine(triangles[i]);
            }

            //Felülírom a tömböm első elemét a már korábban létrehozott háromszögemmel.
            triangles[0] = triangleUser;

            #endregion

            #region DarthBoard

            //Létrehozok egy Dartboard típusú, darthBoard nevű változót, és a 3 paraméteres konstruktor segítségével példányosítom.
            Dartboard darthBoard = new Dartboard(0, 0, 5);

            //A Coordinate osztálynak nem írtunk egyéni konstruktort, így az alapértemzett, nullparaméteres konstruktorral hozom létre a példányt.
            Coordinate firstTry = new Coordinate();
            firstTry.X = 5;
            firstTry.Y = 6;

            //Próbalövés teszteléshez.
            if (darthBoard.IsInside(firstTry))
            {
                Console.WriteLine("I hit the target on the first try!");
            }
            else
            {
                Console.WriteLine("I missed the target on the first try!");
            }
            int score = darthBoard.Score(firstTry);
            Console.WriteLine("My score is:\t" + score);


            //Nullparaméteres konstruktor esetén a példány adattagjai alapértelmezett értéket vesznek fel.
            //Mivel az X és Y változó double, az alapértelmezett értékük 0.0, ezért 0,0 koordinátára fogonk "lőni" vele.
            Coordinate secondTry = new Coordinate();
            if (darthBoard.IsInside(secondTry))
            {
                Console.WriteLine("I hit the target on the second try!");
            }
            else
            {
                Console.WriteLine("I missed the target on the second try!");
            }
            score += darthBoard.Score(secondTry);
            Console.WriteLine("My score is:\t" + score);


            /* 
                Készítsen céllövő játékot: Hozzon létre egy véletlenszerű középpontú céltáblát, majd 
                kérjen be a felhasználótól 15 lövést (pontot) és számolja meg, hány pontnyi találata van a felhasználónak.
                Minden lövés után segítségül közölje, mekkora volt a lövés távolsága a céltáblától
            */
            Dartboard targetTable = new Dartboard(5);
            score = 0;
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i + 1}. shot");
                Console.WriteLine("Give coord X");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Give coord Y");
                int y = int.Parse(Console.ReadLine());
                Console.Clear();
                Coordinate IShootHere = new Coordinate
                {
                    X = x,
                    Y = y
                };
                score += targetTable.Score(IShootHere);
                Console.WriteLine("Your distance is :" + targetTable.DstBetween(IShootHere));
                Console.WriteLine("Your score is :" + score);
            }
            Console.WriteLine("Game over");

            #endregion
            Console.ReadKey();
        }
    }
}
