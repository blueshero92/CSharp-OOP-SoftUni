using Vehicles.Core.Classes;
using Vehicles.Factories.Classes;
using Vehicles.IO.Classes;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            Engine engine = new(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());
            engine.Run();
        }
    }
}