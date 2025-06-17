using WildFarm.Core.Classes;
using WildFarm.Factories.Classes;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Classes;
using WildFarm.IO.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            Engine engine = new Engine(reader, writer, foodFactory, animalFactory);

            engine.Run();
        }
    }
}