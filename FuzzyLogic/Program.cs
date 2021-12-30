using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;
using FuzzyLogic.KnowledgeBase.Visitor;
using FuzzyLogic.src;

namespace FuzzyLogic
{
    class Program
    {
        private static void Main()
        {
            Application.Run(new MainWindow()); 
        }
    }
}
