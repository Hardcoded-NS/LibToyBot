using System;

namespace LibToyBot.Commands
{
    internal class PlaceCommand : ICommand
    {
        private readonly string[] _cmdTokens;

        public PlaceCommand(string[] cmdTokens)
        {
            _cmdTokens = cmdTokens;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

    }
}
