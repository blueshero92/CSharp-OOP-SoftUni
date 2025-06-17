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
            
            IBirthable birthable;
           
            List<IBirthable> livingBeings = new List<IBirthable>();
            
            while ((command = reader.ReadLine()) != "End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 5 && data[0] == "Citizen")
                {
                    birthable = new Citizen(data[1], int.Parse(data[2]), data[3], data[4]);
                }
                else if (data.Length == 3 && data[0] == "Pet") 
                {                                        
                    birthable = new Pet(data[1], data[2]);                                                              
                }
                else
                {
                    continue;
                }
                
                livingBeings.Add(birthable);

            }

            string birthYear = reader.ReadLine();
            

            foreach (IBirthable livingBeing in livingBeings)
            {
                if(livingBeing.Birthdate.EndsWith(birthYear))
                {
                    writer.WriteLine(livingBeing.Birthdate);
                }
            }           
            
        }
    }
}
