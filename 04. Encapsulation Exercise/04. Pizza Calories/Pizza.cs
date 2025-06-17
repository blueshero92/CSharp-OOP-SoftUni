using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string NameArgumentExceptionMessage = "Pizza name should be between 1 and 15 symbols.";
        private string ToppingsCountArgumentExceptionMessage = "Number of toppings should be in range [0..10].";
        private int MinLength = 1;
        private int MaxLength = 15;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            toppings = new List<Topping>();
            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(value.Length < MinLength || value.Length > MaxLength)
                {
                    throw new ArgumentException(NameArgumentExceptionMessage);
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            private set {this.dough = value; } 
        }

        public double Calories => this.Dough.Calories + toppings.Sum(c => c.Calories);

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);

            if (toppings.Count == 10)
            {
                throw new ArgumentException(ToppingsCountArgumentExceptionMessage);
            }
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories.";
        }
    }
}
