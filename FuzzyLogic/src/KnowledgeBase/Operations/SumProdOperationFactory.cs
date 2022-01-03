namespace FuzzyLogic.KnowledgeBase.Operations
{
     class SumProdOperationFactory:IOperationFactory
    {
        public AndOperation CreateAndOperation()
        {
            return new ProdOperation();
        }

        public OrOperation CreateOrOperation()
        {
            return new SumOperation();
        }
    }
}