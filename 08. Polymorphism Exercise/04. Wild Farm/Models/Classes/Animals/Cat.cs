using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes.Animals
{
    public class Cat : Animal, IFeline
    {
        private const double CatWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
            Breed = breed;
        }

        public override double WeightMultiplier => CatWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods =>
            new HashSet<Type>() { typeof(Meat), typeof(Vegetable) };

        public string Breed { get; private set; }

        public string LivingRegion { get; private set; }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
