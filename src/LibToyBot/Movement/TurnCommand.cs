using System;
using System.Collections.Generic;
using System.Linq;
using LibToyBot.Commands;
using LibToyBot.Spatial;

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
            var cmd = cmdTokens?.FirstOrDefault();
            //TODO: validate direction
            var direction = Enum.Parse<Direction>(cmd);
            _movementProcessor.Turn(direction);
        }
    }
}
