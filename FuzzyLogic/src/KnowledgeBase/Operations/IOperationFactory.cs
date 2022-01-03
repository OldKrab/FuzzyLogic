namespace FuzzyLogic.KnowledgeBase.Operations
{
    interface IOperationFactory
    {
        AndOperation CreateAndOperation();
       OrOperation CreateOrOperation();
    }
}