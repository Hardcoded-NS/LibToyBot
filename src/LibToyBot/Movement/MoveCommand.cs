using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Movement
{
    internal class MoveCommand : ICommand
    {
        private readonly IMovementProcessor _movementProcessor;

        public MoveCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _movementProcessor = movementProcessor;
        }
        
        public void Execute(string[] cmdTokens = default)
        {
            _movementProcessor.Move();
        }
    }
}
