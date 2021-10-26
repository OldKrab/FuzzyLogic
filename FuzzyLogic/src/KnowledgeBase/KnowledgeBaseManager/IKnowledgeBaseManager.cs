using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Statements;

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
