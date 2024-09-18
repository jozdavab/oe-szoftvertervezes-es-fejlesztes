using System;
using LAB11_20231120_Teachers.Model;

namespace LAB11_20231120_Teachers.Logic
{
    public static class DogMaintainer
    {
        static readonly Random rnd = new Random();
        public static Dog Breed(Dog a, Dog b)
        {
            Console.WriteLine("Name the pup");
            string name = Console.ReadLine();
            Dog pup;

            int chance = rnd.Next(0, 3);
            switch (chance)
            {
                case 0:
                    pup = new Dog(name, a.Breed); break;
                case 1:
                    pup = new Dog(name, b.Breed); break;
                default:
                    pup = new Dog(name, DogType.mixed); break;
            }

            return pup;
        }

        public static void SetWeight(Dog doggo)
        {
            doggo.Weight = (int)doggo.Breed;
        }
    }
}
