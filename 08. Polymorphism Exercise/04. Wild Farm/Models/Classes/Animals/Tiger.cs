using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes.Animals
{
    public class Tiger : Animal, IFeline
    {
        private const double TigerWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
            Breed = breed;
        }

        public override double WeightMultiplier => TigerWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods =>
            new HashSet<Type>() { typeof(Meat) };

        public string Breed { get; private set; }

        public string LivingRegion { get; private set; }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
