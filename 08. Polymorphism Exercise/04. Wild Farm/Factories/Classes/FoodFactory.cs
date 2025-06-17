using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Classes
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            switch(type)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new Exception("Invalid type of food!");
            }
        }
    }
}
