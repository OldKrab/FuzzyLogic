using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.Commands
{
    class AddTermCommand : IUndoableCommand
    {
        public void Execute()
        {
            var db = KnowledgeBaseManager.GetInstance();
            db.AddTermToVariable(_varName, _termName, _termFunction);
        }

        public void Undo()
        {
            var db = KnowledgeBaseManager.GetInstance();
            db.RemoveTermFromVariable(_varName, _termName);
        }

        private string _varName, _termName;
        private IFunction _termFunction;

        public AddTermCommand(string termName, string varName, IFunction termFunction)
        {
            this._termName = termName;
            _varName = varName;
            _termFunction = termFunction;
        }
    }
}