using System;

namespace LAB11_20231120_Teachers.Model
{
    public class Dog
    {
        private static int numberOfAnimals = 0;
        private static readonly Random rnd = new Random();

        public string ID { get; set; }
        public string Name { get; set; }
        public DogType Breed { get; set; }
        public int Weight { get; set; }

        public Dog()
        {
            numberOfAnimals++;
            ID = GenerateID();
            Name = "Anoymus";
            Breed = (DogType)rnd.Next(0, Enum.GetNames(typeof(DogType)).Length);
        }

        public Dog(string name)
        {
            numberOfAnimals++;
            ID = GenerateID();
            Name = name;

            Console.WriteLine($"Give breed of [{Name}]");
            Console.WriteLine("Possible choices:");
            string[] dogTypes = Enum.GetNames(typeof(DogType));
            foreach (string dogType in dogTypes)
            {
                Console.Write(dogType + ",");
            }
            Console.WriteLine();
            Breed = (DogType)Enum.Parse(typeof(DogType), Console.ReadLine());
        }

        public Dog(string name, DogType breed)
        {
            numberOfAnimals++;
            ID = GenerateID();
            Name = name;
            Breed = breed;
        }

        private string GenerateID()
        {
            string output = $"{numberOfAnimals}-";
            for (int i = 0; i < 5; i++)
            {
                output += (char)rnd.Next('a', 'z' + 1);
            }
            return output;
        }

        public void ShowMe()
        {
            Console.WriteLine($"I am {Name}, a {Breed} with the ID of {ID} and weight of {Weight}");
        }
    }
}
