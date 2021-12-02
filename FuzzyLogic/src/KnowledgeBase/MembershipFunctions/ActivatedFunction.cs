using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class ActivatedFunction : BaseDecoratorFunction
    {
        public ActivatedFunction(IFunction wrappedFunction, IOperation activation, double activatingValue)
            : base(wrappedFunction)
        {
            this.activation = activation;
            this.activatingValue = activatingValue;
        }
        public override double GetValue(double x)
        {
            return activation.Evaluate(wrappedFunction.GetValue(x), activatingValue);
        }

        public override double GetMinValue()
        {
            return wrappedFunction.GetMinValue();
        }

        public override double GetMaxValue()
        {
            return wrappedFunction.GetMaxValue();
        }

        public override string ToString()
        {
            return $"Activated function with activating value = {activatingValue} by operation [{activation}] and wrapped function:\n\t[{wrappedFunction}]";
        }

        private IOperation activation;
        private double activatingValue;
    }
}
