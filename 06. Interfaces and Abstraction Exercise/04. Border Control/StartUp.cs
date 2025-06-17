using _04.BorderControl.Core;
using _04.BorderControl.Core.Interfaces;
using _04.BorderControl.IO;
using _04.BorderControl.IO.Interfaces;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}