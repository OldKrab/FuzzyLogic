
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
   abstract class BaseDecoratorFunction : IMembershipFunction
    {
        protected BaseDecoratorFunction(IMembershipFunction wrappedFunction)
        {
            this.WrappedFunction = wrappedFunction;
        }
        public abstract double GetValue(double x);
        public abstract double GetMinValue();

        public abstract double GetMaxValue();

        protected IMembershipFunction WrappedFunction;

        public void Accept(IKnowledgeVisitor visitor) { }
    }
}
