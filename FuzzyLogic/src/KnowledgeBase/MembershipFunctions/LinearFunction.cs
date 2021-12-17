
namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class LinearFunction : IFunction
    {
        public LinearFunction(float a, float b, bool isIncrease)
        {
            this._a = a;
            this._b = b;
            this._isIncrease = isIncrease;
        }
        public double GetValue(double x)
        {
            if (_isIncrease)
            {
                if (x < _a)
                    return 0;
                if (x < _b)
                    return (x - _a) / (_b - _a);
                return 1;
            }
            else
            {
                if (x < _a)
                    return 1;
                if (x < _b)
                    return (_b - x) / (_b - _a);
                return 0;
            }
        }

        public double GetMinValue()
        {
            return _a;
        }

        public double GetMaxValue()
        {
            return _b;
        }

        private float _a, _b;
        private bool _isIncrease;


    }
}