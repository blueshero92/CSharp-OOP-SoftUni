﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private const int MinValue = 12;
        private const int MaxValue = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinValue, MaxValue)]
        public int Age { get; private set; }
    }
}
