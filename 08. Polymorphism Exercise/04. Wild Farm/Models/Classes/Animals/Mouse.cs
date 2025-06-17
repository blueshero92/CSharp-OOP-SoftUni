using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes.Animals
{
    public class Mouse : Animal, IMammal
    {
        private const double MouseWeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegieon) 
            : base(name, weight)
        {
            LivingRegion = livingRegieon;
        }

        public override double WeightMultiplier => MouseWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods =>
            new HashSet<Type>() { typeof(Fruit), typeof(Vegetable) };

        public string LivingRegion { get; private set; }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
