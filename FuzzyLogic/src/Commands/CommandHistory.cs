using System;
using System.Collections.Generic;

namespace FuzzyLogic.Commands
{
     class CommandHistory
    {
        public void AddCommand(IUndoableCommand command)
        {
            _commands.Push(command);
            Console.WriteLine("Command added to history");
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                Console.WriteLine("Undo command");
                var command = _commands.Peek();
                command.Undo();
                _commands.Pop();
            }
        }

        public static CommandHistory GetInstance()
        {
            return _instance ??= new CommandHistory();
        }

        private Stack<IUndoableCommand> _commands = new Stack<IUndoableCommand>();
        private static CommandHistory _instance;
    }
}