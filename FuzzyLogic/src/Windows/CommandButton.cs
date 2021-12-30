using System;
using System.Windows.Forms;
using FuzzyLogic.Commands;

namespace FuzzyLogic.src
{
    class CommandButton : Button
    {
        public CommandButton()
        {
            Click += ClickButton;
        }

        public void ClickButton(object obj, EventArgs args)
        {
            _command.Execute();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        private ICommand _command;
    }
}