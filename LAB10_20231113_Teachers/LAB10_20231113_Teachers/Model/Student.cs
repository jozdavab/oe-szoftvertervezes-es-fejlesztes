using System;

namespace LAB10_20231113_Teachers.Model
{
    public class Student
    {
        public string Name { get; private set; }
        public string Neptun { get; private set; }
        public DateTime EnrollDate { get; set; }
        public string Course { get; private set; }
        public Subject[] Subjects { get; set; }
        public University Uni { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }   //on the fly property
        public int PassiveSemesterCount { get; set; }

        public Student(string nev, string neptunKod, DateTime szuletes)
        {
            this.Name = nev;
            this.Neptun = neptunKod;
            this.BirthDate = szuletes;
        }

        public bool Enroll(string course)
        {
            if (course == "nappali" || course == "esti" || course == "levelezo")
            {
                this.Course = course;
                return true;
            }
            return false;
        }
        public string ShowMe()
        {
            return ($"> {Name} ({Age}) [{Neptun}] - {EnrollDate.Year} - {Course}\n");
        }
        public string ShowMySubjects()
        {
            string s = $"{Name} tárgyai:\n";
            for (int i = 0; i < Subjects.Length; i++)
            {
                s += $"{Subjects[i].Name}\n";
            }
            return s;
        }
        public string ShowMySubjects(bool hasExam)
        {
            string s = $"{Name} tárgyai:\n";
            for (int i = 0; i < Subjects.Length; i++)
            {
                if (Subjects[i].HasExam == hasExam)
                {
                    s += $"{Subjects[i].Name}\n";
                }
            }
            return s;
        }
        public TimeSpan HappyDays()
        {
            return EnrollDate - BirthDate;
        }
    }
}
