using System;
using System.ComponentModel.DataAnnotations;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Deyan", 32);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
