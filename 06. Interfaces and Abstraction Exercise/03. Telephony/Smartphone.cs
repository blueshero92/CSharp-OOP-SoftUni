using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Call(string number)
        {
            if (number.Any(c => !char.IsDigit(c)))
            {
                Console.WriteLine ("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }

        }
        public void Browse(string url)
        {
            if(url.Any(n => char.IsNumber(n)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }

        }

    }
}
