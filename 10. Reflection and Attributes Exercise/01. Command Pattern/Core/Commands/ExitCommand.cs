﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        private const int DefaultExitValue = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DefaultExitValue);

            return default;
        }
    }
}
