using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public double Fuel
        {
            get { return this.fuel; }
            set { this.fuel = value; }
        }
        public virtual double FuelConsumption => DefaultFuelConsumption;

        public void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
        

    }
}
