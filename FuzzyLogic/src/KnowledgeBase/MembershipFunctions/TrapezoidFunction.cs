using System;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
     class TrapezoidFunction:IFunction
    {
        public TrapezoidFunction(double left, double leftCenter, double rightCenter, double right)
        {
            this._left = left;
            this._leftCenter = leftCenter;
            this._rightCenter = rightCenter;
            this._right = right;
        }

        public override string ToString()
        {
            return $"Trapezoid function with left={_left}, leftCenter={_leftCenter}, rightCenter={_rightCenter}, right={_right}";
        }

        public double GetValue(double x)
        {
            if (x < _left || x > _right)
                return 0;
            if (Math.Abs(x - _leftCenter) < 1e-6 || Math.Abs(x - _rightCenter) < 1e-6 || _leftCenter < x && x < _rightCenter)
                return 1;
            if (x < _leftCenter)
                return (x - _left) / (_leftCenter - _left);
            return (_right - x) / (_right - _rightCenter);
        }

        public double GetMinValue()
        {
            return _left;
        }

        public double GetMaxValue()
        {
            return _right;
        }


        private double _left, _leftCenter, _rightCenter, _right;
    }
}