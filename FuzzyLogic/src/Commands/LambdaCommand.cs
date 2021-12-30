using System;

namespace FuzzyLogic.Commands
{
    class LambdaCommand : ICommand
    {
        public void Execute()
        {
            _func();
        }

        private Action _func;

        public LambdaCommand(Action func)
        {
            _func = func;
        }
    }
}