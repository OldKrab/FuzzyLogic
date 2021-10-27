namespace FuzzyLogic.KnowledgeBase.Operations
{
    class ProdOperation : IOperation
    {
        public double Evaluate(double x, double y)
        {
            return x * y;
        }
        public override string ToString()
        {
            return "Prod";
        }
    }
}
