using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models.Classes
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrease = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, FuelConsumptionIncrease)
        {
        }


        public override void Refuel(double fuel)
        {
            if (this.TankCapacity < fuel + this.FuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            base.Refuel(fuel * 0.95);

        }
    }
}
