using System;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class TrapezoidFunction : IFunction
    {
        public TrapezoidFunction(double left, double leftCenter, double rightCenter, double right)
        {
            Left = left;
            LeftCenter = leftCenter;
            RightCenter = rightCenter;
            Right = right;
        }

        public override string ToString()
        {
            return $"Trapezoid function with left={Left}, leftCenter={LeftCenter}, rightCenter={RightCenter}, right={Right}";
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public double GetValue(double x)
        {
            if (x < Left || x > Right)
                return 0;
            if (Math.Abs(x - LeftCenter) < 1e-6 || Math.Abs(x - RightCenter) < 1e-6 || LeftCenter < x && x < RightCenter)
                return 1;
            if (x < LeftCenter)
                return (x - Left) / (LeftCenter - Left);
            return (Right - x) / (Right - RightCenter);
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
        public double LeftCenter { get; }
        public double RightCenter { get; }
        public double Right { get; }
    }
}