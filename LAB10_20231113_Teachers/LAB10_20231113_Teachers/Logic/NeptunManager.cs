using LAB10_20231113_Teachers.Model;
using System;
using System.IO;

namespace LAB10_20231113_Teachers.Logic
{
    public class NeptunManager
    {
        private int lineNmbr; //Segédváltozó a loghoz
        private readonly Student[] students;

        public NeptunManager()
        {
            students = CreateStudentsFromFile();
        }

        private Student[] CreateStudentsFromFile()
        {
            University OE = new University("Óbudai Egyetem Neumann János Informatikai Kar", "Bécsi út 96/b");

            int rowNumber = 0;

            StreamReader sr = new StreamReader("hallgatokDB.txt");
            while (!sr.EndOfStream) //Amíg nem vagyunk a fájl végén
            {
                sr.ReadLine();      //1 sor beolvasása
                rowNumber++;        //sorok számlálása
            }
            sr.Close();             //Erőforrás felszabadítása.


            Student[] students = new Student[rowNumber];
            int index = 0;

            sr = new StreamReader("hallgatokDB.txt");
            while (!sr.EndOfStream)
            {
                //Józsa Dávid|JML37D|1997.03.27|nappali|2017.09.02
                string line = sr.ReadLine();
                string[] currLine = line.Split('|');

                students[index] = new Student(currLine[0], currLine[1], DateTime.Parse(currLine[2]));

                if (students[index].Enroll(currLine[3]))
                {
                    students[index].EnrollDate = DateTime.Parse(currLine[4]);
                }

                students[index].Subjects = new Subject[6];
                TakeSubjects(students[index].Subjects);

                students[index].Uni = OE;

                index++;
            }
            sr.Close();

            return students;
        }

        private void TakeSubjects(Subject[] subjects)
        {

            StreamReader sr = new StreamReader("targyakDB.txt");
            int subIndex = 0;
            while (!sr.EndOfStream)
            {
                //Villamoságtan (e)|5|1|2017.09.02. 12:00:00
                string line = sr.ReadLine();
                string[] subjectDetails = line.Split('|');
                bool hasExam = false;
                if (int.Parse(subjectDetails[2]) == 1)
                {
                    hasExam = true;
                }

                Subject subject = new Subject(subjectDetails[0], int.Parse(subjectDetails[1]), hasExam, DateTime.Parse(subjectDetails[3]));
                subjects[subIndex++] = subject;
            }
            sr.Close();
        }

        public string ShowStudents()
        {
            string s = "";
            for (int i = 0; i < students.Length; i++)
            {
                s += $"{students[i].ShowMe()}\n";
            }
            Log(s);
            return s;
        }

        //1
        public string AncientOne()
        {
            int mini = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].EnrollDate < students[mini].EnrollDate)
                {
                    mini = i;
                }
            }
            Log(students[mini].ShowMe());
            return students[mini].ShowMe();
        }

        //3
        public string SubjectsOf(int index)
        {
            string s = students[index].ShowMySubjects();
            Log(s);
            return s;
        }

        //4
        public string SubjectsOf(int index, bool vizsgas)
        {
            string s = students[index].ShowMySubjects(vizsgas);
            Log(s);
            return s;
        }

        //5
        public void StudentTakesExam(string neptun, string subject, int grade)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Neptun == neptun)
                {
                    for (int j = 0; j < students[i].Subjects.Length; j++)
                    {
                        if (students[i].Subjects[j].Name == subject)
                        {
                            students[i].Subjects[j].Grade = grade;
                        }
                    }
                }
            }
        }

        //6
        public string ThoseWhoAlreadyTakenExam(string subjectName)
        {
            string s = "";
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = 0; j < students[i].Subjects.Length; j++)
                {
                    if (students[i].Subjects[j].Name == subjectName)
                    {
                        if (students[i].Subjects[j].Grade > 1)
                        {
                            s += $"{students[i].Name} - {students[i].Subjects[j].Grade} \n";
                        }
                    }
                }
            }
            Log(s);
            return s;
        }

        //7
        public string StudentsInCourse(string course, int limit)
        {
            string s = "";
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Course == course)
                {
                    if (students[i].BirthDate.Year <= limit)
                    {
                        s += $"{students[i].ShowMe()}\n";
                    }
                }
            }
            Log(s);
            return s;
        }

        //8
        public string StudentsWithoutPassive(string course, University uni)
        {
            string s = "";
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Course == course && students[i].Uni.Name == uni.Name)
                {
                    if (students[i].PassiveSemesterCount == 0)
                    {
                        s += $"{students[i].ShowMe()}\n";
                    }
                }
            }
            Log(s);
            return s;
        }

        private void Log(string information)
        {
            StreamWriter sw = new StreamWriter("log.txt", true); //Második paraméter igaz esetén hozzáfűz, nem felülír
            sw.WriteLine($"{lineNmbr++}\t{information}\t{DateTime.Now}\n");
            sw.Close();
        }
    }
}
