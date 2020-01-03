using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Movement
{
    internal class MoveCommand : ICommand
    {
        private readonly Stack<Call> _callStack;
        private readonly IMovementProcessor _movementProcessor;

        public MoveCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _callStack = callStack;
            _movementProcessor = movementProcessor;
        }
        
        public void Execute(string[] cmdTokens = default)
        {
            var moveOutcome = _movementProcessor.Move();
            var call = new Call(this, moveOutcome);
            _callStack.Push(call);
        }
    }
}
