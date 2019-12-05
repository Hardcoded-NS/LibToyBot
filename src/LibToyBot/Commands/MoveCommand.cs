using System;
using System.Collections.Generic;

namespace LibToyBot.Commands
{
    internal class MoveCommand : ICommand
    {
        private readonly IMovementProcessor _movementProcessor;

        public MoveCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _movementProcessor = movementProcessor;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
