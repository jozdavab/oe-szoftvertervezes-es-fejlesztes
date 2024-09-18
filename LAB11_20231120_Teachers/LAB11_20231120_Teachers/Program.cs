using System;
using LAB11_20231120_Teachers.Logic;
using LAB11_20231120_Teachers.Model;
using LAB11_20231120_Teachers.Util;

namespace LAB11_20231120_Teachers
{
    public class Program
    {
        static void Main()
        {
            Dog doggo = new Dog("Rex");
            Dog goodBoi = new Dog("Lessie");

            doggo.ShowMe();
            goodBoi.ShowMe();

            Dog puppy = DogMaintainer.Breed(doggo, goodBoi);
            puppy.ShowMe();

            Dog[] dogs = new Dog[10];
            dogs[0] = doggo;
            dogs[1] = goodBoi;
            dogs[2] = puppy;

            for (int i = 3; i < dogs.Length; i++)
            {
                dogs[i] = new Dog();
            }

            Console.WriteLine("Foreach");
            foreach (Dog currentDog in dogs)
            {
                currentDog.ShowMe();
            }

            Console.Clear();
            dogs = IOHelper.ReadFile();

            foreach (Dog currentDog in dogs)
            {
                DogMaintainer.SetWeight(currentDog);
                currentDog.ShowMe();
            }

            IOHelper.WriteFile(dogs);

            Console.ReadKey();
        }
    }
}
