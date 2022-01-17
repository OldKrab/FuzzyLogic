using FuzzyLogic.Algorithm;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic
{
    public class FuzzySystem
    {
        public static FuzzySystem GetInstance()
        {
            return _instance ??= new FuzzySystem();
        }

        public FuzzyAlgorithm FuzzyAlgorithm { get; set; }

        public KnowledgeBaseManager KnowledgeBase { get; set; }

        private FuzzySystem()
        {
            FuzzyAlgorithm = new MamdaniAlgorithm();
            KnowledgeBase = new KnowledgeBaseManager();
        }

        private static FuzzySystem _instance;
    }
}