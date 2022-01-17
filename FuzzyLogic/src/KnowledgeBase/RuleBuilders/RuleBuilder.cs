using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.RuleBuilders
{
    class RuleBuilder : IRuleBuilder
    {
        public IRuleBuilder AddCondition(Variable var, Term term)
        {
            if (!var.IsInput)
                throw new InvalidOperationException($"Переменная {var.Name} не является входной!");
            var cond = new SingleCondition(var, term);
            return AddCondition(cond);
        }

        private IRuleBuilder AddCondition(ICondition cond)
        {
            if (_curList == null)
                _curList = new ConditionList(cond);
            else
            {
                if (_curOperation == null)
                    throw new InvalidOperationException("Не определена операция перед условием!");
               
                _curList.AddCondition(cond, _curOperation);
                _curOperation = null;
            }

            return this;
        }

        public IRuleBuilder AddOperation(IOperation operation)
        {
            if (_curList == null || _curOperation != null)
                throw new InvalidOperationException("Не определено условие перед операцией!");
            _curOperation = operation;
            return this;
        }

        public IRuleBuilder StartConditionList()
        {
            _stack.Push((_curOperation, _curList));
            _curOperation = null;
            _curList = null;
            return this;
        }

        public IRuleBuilder EndConditionList()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException("Перед закрывающей скобкой нет открывающей!");
            if (_curList == null)
                throw new InvalidOperationException("В скобках нет условий!");

            var addedList = _curList;
            (_curOperation, _curList) = _stack.Peek();
            _stack.Pop();

            return AddCondition(addedList);
        }

        public IRuleBuilder AddConclusion(Variable var, Term term)
        {
            if (var.IsInput)
                throw new InvalidOperationException($"Переменная {var.Name} не является выходной!");
            _conclusions.Add(new Statement(var, term));
            return this;
        }

        public IRuleBuilder Clear()
        {
            _stack.Clear();
            _conclusions = new List<Statement>();
            _curList = null;
            _curOperation = null;
            return this;
        }

        public Rule GetResult()
        {
            if (_stack.Count > 0)
                throw new InvalidOperationException("После открывающей скобки нет закрывающей!");
            return new Rule(_curList, _conclusions);
        }

        private readonly Stack<(IOperation, ConditionList)> _stack = new Stack<(IOperation, ConditionList)>();
        private ConditionList _curList;
        private IOperation _curOperation;
        private List<Statement> _conclusions = new List<Statement>();
    }
}