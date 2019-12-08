using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Movement
{
    internal class TurnCommand : ICommand
    {
        private readonly IMovementProcessor _movementProcessor;

        public TurnCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _movementProcessor = movementProcessor;
        }

        public void Execute(string[] cmdTokens = default)
        {
            throw new NotImplementedException();
        }
    }
}
