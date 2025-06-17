using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes.Animals
{
    public class Dog : Animal, IMammal
    {
        private const double DogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegieon) 
            : base(name, weight)
        {
            LivingRegion = livingRegieon;
        }

        public override double WeightMultiplier => DogWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods =>
             new HashSet<Type>() { typeof(Meat) };

        public string LivingRegion { get; private set; }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
