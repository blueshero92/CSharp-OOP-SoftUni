using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models.Classes
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, FuelConsumptionIncrease)
        {
        }
    }
}
