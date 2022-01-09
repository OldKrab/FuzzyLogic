namespace FuzzyLogic.KnowledgeBase.Operations
{
    class MaxMinOperationFactory : IOperationFactory
    {
        public IAndOperation CreateAndOperation()
        {
            return new MinOperation();
        }

        public IOrOperation CreateOrOperation()
        {
            return new MaxOperation();
        }
    }
}