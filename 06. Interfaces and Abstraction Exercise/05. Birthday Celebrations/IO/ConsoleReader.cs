using _04.BorderControl.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
        
    }
}
