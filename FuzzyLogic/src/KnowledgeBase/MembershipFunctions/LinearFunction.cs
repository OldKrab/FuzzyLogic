
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class LinearFunction : IFunction
    {
        public LinearFunction(double a, double b, bool isIncrease)
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
            return (IsIncrease ? "Возрастающая" : "Убывающая") + $" линейная функция с параметрами left={Left}, right={Right}";
        }

        public double GetMinValue()
        {
            return Left;
        }

        public double GetMaxValue()
        {
            return Right;
        }

        public double Left { get; }
        public double Right { get; }
        public bool IsIncrease { get; }


        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}