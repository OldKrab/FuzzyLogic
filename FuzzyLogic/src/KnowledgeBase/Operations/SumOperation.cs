namespace FuzzyLogic.KnowledgeBase.Operations
{
    class SumOperation : OrOperation
    {
        public double Evaluate(double x, double y)
        {
            return x + y;
        }

        public override string ToString()
        {
            return "Sum";
        }
    }
}
