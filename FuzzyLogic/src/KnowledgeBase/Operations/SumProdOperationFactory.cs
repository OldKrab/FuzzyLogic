namespace FuzzyLogic.KnowledgeBase.Operations
{
    class SumProdOperationFactory : IOperationFactory
    {
        public IAndOperation CreateAndOperation()
        {
            return new ProdOperation();
        }

        public IOrOperation CreateOrOperation()
        {
            return new SumOperation();
        }
    }
}