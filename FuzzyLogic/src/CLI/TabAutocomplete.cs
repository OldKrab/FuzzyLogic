using System;
using System.Collections.Generic;

namespace FuzzyLogic.CLI
{
    public class TabAutocomplete
    {

        public TabAutocomplete(List<string> commands)
        {
            _commands = commands;
        }

        public List<string> GetMatchingCommands(string commandStart)
        {
            return _commands.FindAll(s => s.StartsWith(commandStart, StringComparison.InvariantCultureIgnoreCase));
        }

        private readonly List<string> _commands;
    }
}