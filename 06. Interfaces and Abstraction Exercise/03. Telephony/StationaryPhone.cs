using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            if (number.Any(c => !char.IsDigit(c)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {number}");
            }

        }
    }
}
