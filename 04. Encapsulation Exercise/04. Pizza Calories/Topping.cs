using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private double BaseCaloriesPerGram = 2;
        private string TypeArgumentExceptionMessage = "Cannot place {0} on top of your pizza.";
        private string WeigthArgumentExceptionMessage = "{0} weight should be in the range [1..50].";

        private double MinWeigth = 1;
        private double MaxWeigth = 50;

        private string type;
        private double weigth;
        private Dictionary<string, double> toppingTypeCalories;

        public Topping(string type, double weigth)
        {
            toppingTypeCalories = new Dictionary<string, double> { {"meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

            Type = type;
            Weigth = weigth;
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (!toppingTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(TypeArgumentExceptionMessage, value));
                }

                this.type = value;
            }
        }

        public double Weigth
        {
            get { return this.weigth; }
            private set
            {
                if(value < MinWeigth || value > MaxWeigth)
                {
                    throw new ArgumentException(string.Format(WeigthArgumentExceptionMessage, Type));
                }

                this.weigth = value;
            }
        }

        public double Calories
        {
            get
            {
                double toppingCaloriesModifier = toppingTypeCalories[Type.ToLower()];

                return BaseCaloriesPerGram * toppingCaloriesModifier * Weigth;
            }
        }

    }
}
