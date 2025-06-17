using Raiding.Core.Classes;
using Raiding.Core.Interfaces;
using Raiding.Factories.Classes;
using Raiding.Factories.Interfaces;
using Raiding.IO.Classes;
using Raiding.IO.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroCreate creator = new HeroCreate();
            Engine engine = new(reader, writer, creator);
            engine.Run();
        }
    }
}