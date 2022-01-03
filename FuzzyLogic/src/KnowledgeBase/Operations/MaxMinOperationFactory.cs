namespace FuzzyLogic.KnowledgeBase.Operations
{
     class MaxMinOperationFactory:IOperationFactory
    {
        public AndOperation CreateAndOperation()
        {
            return new MinOperation();
        }

        public OrOperation CreateOrOperation()
        {
            return new MaxOperation();
        }
    }
}