using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Classes.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core.Classes
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly ICollection<IAnimal> animals;


        public Engine(IReader reader, IWriter writer, 
            IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;

            animals = new List<IAnimal>();  
        }

        public void Run()
        {
            string command;

            while((command = reader.ReadLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(command);

                    IFood food = CreateFood();

                    writer.WriteLine(animal.ProduceSound());

                    animal.Eat(food);

                }
                catch(ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    throw;
                }

                animals.Add(animal);
            }

            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }

        }

        private IAnimal CreateAnimal(string command)
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.CreateAnimal(tokens);

            return animal;
        }

        private IFood CreateFood()
        {
            string[] foodTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodTokens[0];
            int foodQuantity = int.Parse(foodTokens[1]);

            IFood food = foodFactory.CreateFood(foodType, foodQuantity);

            return food;
        }
    }
}
