using Vehicles.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;
using Vehicles.Models.Classes;
using Vehicles.Factories.Interfaces;

namespace Vehicles.Core.Classes
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
            vehicles = new List<IVehicle>();
        }

        public void Run()
        {

            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int vehiclesCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < vehiclesCount; i++)
            {
                try
                {
                    ProcessCommand();

                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }

            }

            foreach (IVehicle vh in vehicles)
            {
                writer.WriteLine(vh.ToString());
            }

        }

        private IVehicle CreateVehicle()
        {
            string[] tokens = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);
            double tankCapacity = double.Parse(tokens[3]);

            IVehicle vehicle = vehicleFactory.Create(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] command = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = command[0];
            string vehicleType = command[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type.");
            }

            if (commandType == "Drive")
            {
                double distance = double.Parse(command[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (commandType == "DriveEmpty")
            {
                double distance = double.Parse(command[2]);
                writer.WriteLine(vehicle.Drive(distance, false));
            }
            else if (commandType == "Refuel")
            {
                double fuel = double.Parse(command[2]);
                vehicle.Refuel(fuel);
            }


        }
    }
}
