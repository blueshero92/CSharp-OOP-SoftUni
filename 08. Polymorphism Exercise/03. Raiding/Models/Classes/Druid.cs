﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models.Classes
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name) 
            : base(name, DruidPower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
