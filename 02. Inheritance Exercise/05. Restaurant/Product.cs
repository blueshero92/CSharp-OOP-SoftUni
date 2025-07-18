﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Product
    {
        private string name;
        private decimal price;

        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
