using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Movement
{
    internal class TurnCommand : ICommand
    {
        private readonly string[] _cmdTokens;
        private readonly IMovementProcessor _movementProcessor;

        public TurnCommand(Stack<Call> callStack, string[] cmdTokens, IMovementProcessor movementProcessor)
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
