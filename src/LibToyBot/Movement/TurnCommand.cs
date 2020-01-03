using System;
using System.Collections.Generic;
using System.Linq;
using LibToyBot.Commands;
using LibToyBot.Spatial;

namespace LibToyBot.Movement
{
    internal class TurnCommand : ICommand
    {
        private readonly Stack<Call> _callStack;
        private readonly IMovementProcessor _movementProcessor;

        public TurnCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _callStack = callStack;
            _movementProcessor = movementProcessor;
        }

        public void Execute(string[] cmdTokens = default)
        {
            //single element with the direction to turn
            var cmd = cmdTokens?.FirstOrDefault();
            var direction = Enum.Parse<Direction>(cmd);
            var outcome = _movementProcessor.Turn(direction); 
            _callStack.Push(new Call(this, outcome));
        }
    }
}
