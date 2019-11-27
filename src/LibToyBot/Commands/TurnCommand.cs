using System;

namespace LibToyBot.Commands
{
    internal class TurnCommand : ICommand
    {
        private readonly string[] _cmdTokens;

        public TurnCommand(string[] cmdTokens)
        {
            _cmdTokens = cmdTokens;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
