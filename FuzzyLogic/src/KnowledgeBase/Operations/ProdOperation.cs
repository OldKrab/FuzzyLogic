namespace FuzzyLogic.KnowledgeBase.Operations
{
    class ProdOperation : AndOperation
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
