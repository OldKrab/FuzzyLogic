using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic.Commands
{
    class AddVariableCommand : IUndoableCommand
    {
        public AddVariableCommand(string name, bool isInput)
        {
            _name = name;
            _isInput = isInput;
        }

        public void Execute()
        {
            var db = KnowledgeBaseManager.GetInstance();
            db.AddVariable(_name, _isInput);
        }

        public void Undo()
        {
            var db = KnowledgeBaseManager.GetInstance();
            db.RemoveVariable(_name);
        }

        private string _name;
        private bool _isInput;
    }
}