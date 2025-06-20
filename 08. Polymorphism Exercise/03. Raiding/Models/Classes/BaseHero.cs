﻿using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models.Classes
{
    public abstract class BaseHero : IHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }
        

        public int Power { get; private set; }

        public abstract string CastAbility();
        
    }
}
