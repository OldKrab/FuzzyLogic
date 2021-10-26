
namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
   abstract class BaseDecoratorFunction : IMembershipFunction
    {
        protected BaseDecoratorFunction(IMembershipFunction wrappedFunction)
        {
            this.wrappedFunction = wrappedFunction;
        }
        public abstract double GetValue(double x);

        protected IMembershipFunction wrappedFunction;
    }
}
