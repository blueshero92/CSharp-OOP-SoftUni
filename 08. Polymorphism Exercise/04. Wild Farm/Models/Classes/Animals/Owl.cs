using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes.Animals
{
    public class Owl : Animal, IBird
    {
        private const double OwlWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override double WeightMultiplier => OwlWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods =>
            new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
