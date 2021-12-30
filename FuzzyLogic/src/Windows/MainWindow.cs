using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FuzzyLogic.Commands;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.src
{
    public partial class MainWindow : Form
    {
        BindingSource bs = new BindingSource();

        public MainWindow()
        {
            InitializeComponent();

            functionTypeBox.Items.Add(new TriangularFunction(1, 2, 3));
            functionTypeBox.Items.Add(new TrapezoidFunction(1, 2, 3, 4));
            functionTypeBox.Items.Add(new LinearFunction(1, 2, false));

            addTermButton.SetCommand(new LambdaCommand(() =>
            {
                var command = new AddCommandToHistory(
                    new AddTermCommand(
                        termNameTextbox.Text,
                        termVarTextbox.Text,
                        (IFunction)functionTypeBox.SelectedItem
                ));
                command.Execute();
            }));

            addVarButton.SetCommand(new LambdaCommand(() =>
            {
                var command = new AddCommandToHistory(
                    new AddVariableCommand(
                        varNameTextbox.Text,
                        varInputCheckbox.Checked
                    ));
                command.Execute();
            }));

            undoButton.SetCommand(new LambdaCommand(() =>
            {
                CommandHistory.GetInstance().Undo();
            }));

            refreshButton.SetCommand(new LambdaCommand(UpdateVars));

            bs.DataSource = KnowledgeBaseManager.GetInstance().Variables;
            varsListbox.DataSource = bs;
        }

        private void UpdateVars()
        {
            var selectedVar = varsListbox.SelectedItem;
            // Update items of listbox
            varsListbox.DataSource = null;
            varsListbox.DataSource = KnowledgeBaseManager.GetInstance().Variables;
            varsListbox.SelectedItem = selectedVar;
            UpdateTerms();
        }

        private void UpdateTerms()
        {
            var selectedVar = (Variable)varsListbox.SelectedItem;
            termsListbox.DataSource = null;
            if (selectedVar != null)
            {
                termsListbox.DataSource = selectedVar.Terms;
            }
        }

    }
}
