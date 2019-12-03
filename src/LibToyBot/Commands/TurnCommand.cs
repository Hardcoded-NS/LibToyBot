using System;

namespace LibToyBot.Commands
{
    internal class TurnCommand : ICommand
    {
        private readonly string[] _cmdTokens;
        private readonly IMovementProcessor _movementProcessor;

        public TurnCommand(string[] cmdTokens, IMovementProcessor movementProcessor)
        {
            _cmdTokens = cmdTokens;
            _movementProcessor = movementProcessor;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
