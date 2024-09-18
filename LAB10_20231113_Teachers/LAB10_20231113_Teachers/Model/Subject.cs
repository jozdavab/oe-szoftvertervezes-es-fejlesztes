using System;

namespace LAB10_20231113_Teachers.Model
{
    public class Subject
    {
        public Subject(string name, int creditValue, bool hasExam, DateTime date)
        {
            this.Name = name;
            this.CreditValue = creditValue;
            this.HasExam = hasExam;
            this.Date = date;
        }

        public string Name { get; set; }
        public int CreditValue { get; set; }
        public bool HasExam { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
    }
}
