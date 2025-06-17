using _04.BorderControl.Core.Interfaces;
using _04.BorderControl.IO.Interfaces;
using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            IIdentifiabe identifiable;

            List<IIdentifiabe> beings = new List<IIdentifiabe>();
            
            while ((command = reader.ReadLine()) != "End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    identifiable = new Citizen(data[0], int.Parse(data[1]), data[2]);                    
                }
                else
                {
                    identifiable = new Robot(data[0], data[1]);

                }
                
                beings.Add(identifiable);

            }

            string fakeNumber = reader.ReadLine();

            List<string> fakeIds = new List<string>();

            foreach (IIdentifiabe being in beings)
            {
                if(being.Id.EndsWith(fakeNumber))
                {
                    fakeIds.Add(being.Id);
                }
            }

            foreach(string fakeId in fakeIds)
            {
                writer.WriteLine(fakeId);
            }
            
        }
    }
}
