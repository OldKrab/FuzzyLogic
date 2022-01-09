namespace FuzzyLogic.KnowledgeBase.Operations
{
    interface IOperationFactory
    {
        IAndOperation CreateAndOperation();
        IOrOperation CreateOrOperation();
    }
}