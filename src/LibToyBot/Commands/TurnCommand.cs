using System;
using System.Windows.Input;

namespace LibToyBot.Commands
{
    internal class TurnCommand : ICommand
    {
        private readonly string[] _cmdTokens;

        public TurnCommand(string[] cmdTokens)
        {
            _cmdTokens = cmdTokens;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
