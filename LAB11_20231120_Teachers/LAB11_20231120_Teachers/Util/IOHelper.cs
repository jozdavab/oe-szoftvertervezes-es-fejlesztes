using System;
using System.IO;
using LAB11_20231120_Teachers.Model;

namespace LAB11_20231120_Teachers.Util
{
    public static class IOHelper
    {
        public static Dog[] ReadFile()
        {
            StreamReader sr = new StreamReader("kutyak.dat");
            Dog[] dogs = new Dog[int.Parse(sr.ReadLine())];
            for (int i = 0; i < dogs.Length; i++)
            {
                string[] splittedLine = sr.ReadLine().Split('#');
                dogs[i] = new Dog(splittedLine[0], (DogType)Enum.Parse(typeof(DogType), splittedLine[1]));
            }
            sr.Close();
            return dogs;
        }

        public static void WriteFile(Dog[] dogs)
        {
            StreamWriter sw = new StreamWriter("fajtatiszta.dat", true);
            foreach (Dog dog in dogs)
            {
                if (dog.Breed != DogType.mixed)
                {
                    sw.WriteLine(dog.ID);
                }
            }
            sw.Close();
        }
    }
}
