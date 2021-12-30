
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class LinearFunction : IFunction
    {
        public LinearFunction(float a, float b, bool isIncrease)
        {
            this.Left = a;
            this.Right = b;
            this.IsIncrease = isIncrease;
        }
        public double GetValue(double x)
        {
            if (IsIncrease)
            {
                if (x < Left)
                    return 0;
                if (x < Right)
                    return (x - Left) / (Right - Left);
                return 1;
            }
            else
            {
                if (x < Left)
                    return 1;
                if (x < Right)
                    return (Right - x) / (Right - Left);
                return 0;
            }
        }

        public override string ToString()
        {
            return $"Linear function with left={Left}, right={Right}, " + (IsIncrease ? "increase" : "decrease");
        }

        public double GetMinValue()
        {
            return Left;
        }

        public double GetMaxValue()
        {
            return Right;
        }

        public float Left { get; }
        public float Right { get; }
        public bool IsIncrease { get; }


        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}