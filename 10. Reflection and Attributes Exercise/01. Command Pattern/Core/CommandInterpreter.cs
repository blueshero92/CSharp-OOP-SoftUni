﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string InvalidCommandExceptionMessage = "Invalid command type!";
        public string Read(string args)
        {
            string[] arguments = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType is null)
            {
                throw new InvalidOperationException(InvalidCommandExceptionMessage);
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string result = command.Execute(commandArguments);

            return result.ToString();
        }
    }
}
