namespace FuzzyLogic.Commands
{
    class AddCommandToHistory : ICommand
    {
        public void Execute()
        {
            _command.Execute();
            var ch = CommandHistory.GetInstance();
            ch.AddCommand(_command);
        }

        private IUndoableCommand _command;

        public AddCommandToHistory(IUndoableCommand command)
        {
            _command = command;
        }
    }
}