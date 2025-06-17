using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes.Animals
{
    public class Hen : Animal, IBird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public override double WeightMultiplier => HenWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods => 
            new HashSet<Type>() { typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable)};

        public double WingSize { get; private set; }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
