namespace FuzzyLogic.Commands
{
    interface IUndoableCommand : ICommand
    {
        void Undo();
    }
}