using FuzzyLogic.src.KnowledgeBase;
using FuzzyLogic.src.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.src.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.KnowledgeBaseManager
{
    interface IKnowledgeBaseManager
    {
        Variable AddVariable(string name, bool isInputVar);
        Term AddTerm(string name, IMembershipFunction func);
        Conclusion AddConclusion(uint varId, uint termId);
        SingleCondition AddSingleCondition(uint varId, uint termId);
    }
}
