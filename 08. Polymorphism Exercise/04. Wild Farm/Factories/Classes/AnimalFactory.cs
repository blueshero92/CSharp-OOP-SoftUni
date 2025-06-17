using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Classes.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Classes
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalTokens)
        {
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weigth = double.Parse(animalTokens[2]);


            switch(type)
            {
                case "Owl":
                    return new Owl(name, weigth, double.Parse(animalTokens[3]));
                case "Hen":
                    return new Hen(name, weigth, double.Parse(animalTokens[3]));
                case "Dog":
                    return new Dog(name, weigth, animalTokens[3]);
                case "Mouse":
                    return new Mouse(name, weigth, animalTokens[3]);
                case "Cat":
                    return new Cat(name, weigth, animalTokens[3], animalTokens[4]);
                case "Tiger":
                    return new Tiger(name, weigth, animalTokens[3], animalTokens[4]);
                default:
                    throw new Exception("Invalid animal type!");
            }
        }
    }
}
