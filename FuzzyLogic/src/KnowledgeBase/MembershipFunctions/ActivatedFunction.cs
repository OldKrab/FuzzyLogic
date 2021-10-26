using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class ActivatedFunction : BaseDecoratorFunction
    {
        public ActivatedFunction(IMembershipFunction wrappedFunction, IOperation activation, double activatingValue)
            : base(wrappedFunction)
        {
            this.activation = activation;
            this.activatingValue = activatingValue;
        }
        public override double GetValue(double x)
        {
            return activation.Evaluate(wrappedFunction.GetValue(x), activatingValue);
        }

        public override string ToString()
        {
            return $"Activated function with activating value = {activatingValue} by operation [{activation}] and wrapped function:\n\t[{wrappedFunction}]";
        }

        private IOperation activation;
        private double activatingValue;
    }
}
