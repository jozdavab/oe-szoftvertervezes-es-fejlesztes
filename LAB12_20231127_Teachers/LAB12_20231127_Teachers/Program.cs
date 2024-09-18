using System;
using System.IO;

namespace LAB12_20231127_Teachers
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             * Az elkészült osztályok működését tesztelje a főprogram Main metódusában. Hozzon létre egy Album példányt,
             * amelynek a mellékelt bemeneti fájlt adja át (metallica-load.txt). Kérdezze le és írja fájlba hogy Hammett
             * mely számoknál jelenik meg szerzőként. 
             */
            Album album = new Album("Metallica", "Load", "metallica-load.txt");
            string kimenet = album.Lekerdez("Hammett");

            string kimenetNev = "kimenet.txt";
            StreamWriter sw = new StreamWriter(kimenetNev);
            sw.Write(kimenet);
            sw.Close();
            Console.WriteLine($"Kimenet kiírva a {kimenetNev} fájlba.");
            Console.ReadKey();
        }
    }
}
