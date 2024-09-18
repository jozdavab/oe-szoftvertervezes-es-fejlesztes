namespace LAB10_20231113_Teachers.Model
{
    public class University
    {
        public University(string name, string adress)
        {
            this.Name = name;
            this.Adress = adress;
        }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
