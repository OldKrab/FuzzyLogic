using FuzzyLogic.src.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.src.KnowledgeBase.Operations;
using System;
using FuzzyLogic.KnowledgeBase.KnowledgeBaseManager;

namespace FuzzyLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new KnowledgeBaseManagerLogger(new KnowledgeBaseManager());
            var inVar = manager.AddVariable("Speed", true);
            var outVar = manager.AddVariable("Acceleration", false);
            manager.AddTerm("Slow", new TriangularFunction(20, 40, 60));
            var term1 = manager.AddTerm("Medium", new TriangularFunction(40, 60, 80));
            var term2 = manager.AddTerm("Fast", new TriangularFunction(60, 90, 120));
            manager.AddTerm("Very fast", new TriangularFunction(90, 150, 150));
            manager.AddSingleCondition(inVar.Id, term1.Id);
            manager.AddConclusion(outVar.Id, term2.Id);
        }
    }
}
