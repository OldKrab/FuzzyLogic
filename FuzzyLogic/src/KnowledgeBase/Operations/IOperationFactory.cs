namespace FuzzyLogic.KnowledgeBase.Operations
{
    public interface IOperationFactory
    {
        IAndOperation CreateAndOperation();
        IOrOperation CreateOrOperation();
    }
}