using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Classes.Animals;

namespace WildFarm.Models.Interfaces
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
