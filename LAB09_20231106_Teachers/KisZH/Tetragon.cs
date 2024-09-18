using System;

namespace KisZH
{
    //Készítsen osztályt egy tetragon reprezentálására!  
    public class Tetragon
    {
        private static readonly Random random = new Random();

        //Az osztály rendelkezzen szélességgel, magassággal, illetve X és Y koordinátával.
        //Az adattagokat ne lehessen elérni az osztályon kívülről.
        private readonly int x;
        private readonly int y;
        private readonly int Width;
        private readonly int Height;

        //Az osztálynak legyen kétparaméteres konstruktora, amely a tetragon max szélességét és max hosszúságát kapja meg.
        public Tetragon(int maxWidth, int maxHeight)
        {
            //A konstruktor állítsa be a szélesség és magasság értékét
            //1 és a kapott maximum közötti véletlen számra.
            this.Height = random.Next(1, maxHeight + 1);
            this.Width = random.Next(1, maxWidth + 1);

            //Az X és Y koordináták értéke 0 és a konzol hossza/magassága között legyen beállítva,
            //úgy, hogy a tetragon ne lóghasson túl a konzol szélén.
            this.x = random.Next(Console.WindowWidth - Width + 1);
            this.y = random.Next(Console.WindowHeight - Height + 1);
        }

        //Az osztálynak legyen egy publikus metódusa, amely képes a konzol megfelelő pozíciójában,
        //a megadott szélességgel és magassággal kirajzolni ’#’ karakterekből a tetragont.
        public void ShowMe()
        {
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("#");
                }
            }
        }

        //Egy fokkal látványosabb, alternatív megoldás:
        /*
        public void ShowMe()
        {
            Console.BackgroundColor = (ConsoleColor)random.Next(16);
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(" ");
                }
            }
            Console.ResetColor();
        }
        */
    }
}
