using System;
using System.Collections.Generic;
using System.Linq;
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
            //single element with the direction to turn
            var direction = cmdTokens?.FirstOrDefault();
            //TODO: validate direction
            _movementProcessor.Turn(direction);
        }
    }
}
