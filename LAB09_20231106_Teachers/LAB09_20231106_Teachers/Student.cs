
namespace LAB09_20231106_Teachers
{
    public class Student
    {

        private int age;    //Adattag

        public int Age      //Property adattaghoz
        {
            get //Olvasáskor hívódik meg
            {
                return age;
            }
            set //Íráskor hívódik meg
            {
                //Saját logikai is írható a get vagy a set ághoz
                if (value < 0)
                {
                    age = value * -1;
                }
                else
                {
                    age = value;
                }
            }
        }

        public string Name { get; private set; } //Autoproperty olvasáshoz és belső íráshoz

        public string University { get; set; }  //Autoproperty íráshoz és olvasáshoz

        //----------------------------------------CTOR
        public Student(string name, int age, string university)
        {
            Name = name;
            Age = age;                  //Tulajdonságon keresztül állítom be!
            //this.age = age            //Nem pedig így, mezőn keresztül
            University = university;
        }

        //----------------------------------------METHOD
        public string ShowMe()
        {
            return $"I am {Name}, a {age} yrs old student of {University}";
        }
    }
}
