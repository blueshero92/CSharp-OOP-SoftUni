﻿using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            uint age = uint.Parse(Console.ReadLine());

            if (age > 15)
            {
                Person person = new(name, age);

                Console.WriteLine(person);
            }
            else
            {
                Child child = new(name, age);

                Console.WriteLine(child);
            }
        }
    }
}