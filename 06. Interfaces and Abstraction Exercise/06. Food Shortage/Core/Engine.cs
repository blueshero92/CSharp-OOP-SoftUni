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
            
            IBuyer buyer;
           
            List<IBuyer> people = new List<IBuyer>();

            int peopleCount = int.Parse(reader.ReadLine());

            for(int person = 0; person < peopleCount; person++)
            {
                string[] data = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 4)
                {
                    buyer = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
                }
                else  
                {                                        
                    buyer = new Rebel(data[0], int.Parse(data[1]), data[2]);                                                              
                }

                people.Add(buyer);
            }

            string name;

            while ((name = reader.ReadLine()) != "End")
            {
                
                IBuyer buyGuy = people.FirstOrDefault(p => p.Name == name);

                if(buyGuy != null)
                {                   
                    buyGuy.BuyFood();
                }

            }
            
            int totalFood = people.Sum(p => p.Food);

            writer.WriteLine(totalFood.ToString());
                                
            
        }
    }
}
