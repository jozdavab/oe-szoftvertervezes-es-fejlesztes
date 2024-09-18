using LAB10_20231113_Teachers.Logic;
using LAB10_20231113_Teachers.Model;
using System;

namespace LAB10_20231113_Teachers
{
    public class Program
    {
        static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("0. TimeSpan teszt. Hány évig voltam boldog?");
            Student ItsMee = new Student("Józsa Dávid", "JML37D", DateTime.Parse("1997.03.27"))
            {
                EnrollDate = DateTime.Parse("2017.09.02")
            };
            Console.WriteLine(ItsMee.HappyDays().Days / 365);


            NeptunManager nm = new NeptunManager();
            Console.WriteLine(nm.ShowStudents());


            Console.WriteLine("1. legrégebb óta ittlévő hallgató(beiratkozás tekintetében)");
            Console.WriteLine(nm.AncientOne());


            Console.WriteLine("2. Adott hallgató tárgyainak kilistázása");
            Console.Write("Adjon meg egy hallgato indexet:\t");
            int studentIndex = int.Parse(Console.ReadLine());
            Console.WriteLine(nm.SubjectsOf(studentIndex));


            Console.WriteLine("3. Adott hallgató vizsgás tárgyainak kilistázása");
            Console.Write("Adjon meg egy hallgato indexet:\t");
            studentIndex = int.Parse(Console.ReadLine());
            Console.WriteLine(nm.SubjectsOf(studentIndex, true));


            Console.WriteLine("4. Adott hallgató vizsgázik");
            nm.StudentTakesExam("JML37D", "Szoftvertervezs és fejlesztés I.", rnd.Next(1, 6));


            Console.WriteLine("5. Azokat a hallgatókat kérjük le, akik adott tárgyból vizsgáztak már");
            Console.WriteLine(nm.ThoseWhoAlreadyTakenExam("Szoftvertervezs és fejlesztés I."));


            Console.WriteLine("6. Nappali tagozatos hallgatók listázása, akik 1990 előtt születtek");
            Console.WriteLine(nm.StudentsInCourse("nappali", 1990));


            Console.WriteLine("7. Esti tagozatos hallgatók, akik a NIK-re járnak ÉS nem volt passzív félévük még");
            Console.WriteLine(nm.StudentsWithoutPassive("esti", new University("Óbudai Egyetem Neumann János Informatikai Kar", "Bécsi út 96/b")));

            Console.ReadKey();
        }
    }
}
