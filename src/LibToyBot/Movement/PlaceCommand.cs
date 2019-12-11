using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using LibToyBot.Commands;
using LibToyBot.Spatial;

namespace LibToyBot.Movement
{
    internal class PlaceCommand : ICommand
    {
        private readonly Stack<Call> _callStack;
        private readonly IMovementProcessor _movementProcessor;

        public PlaceCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _callStack = callStack;
            _movementProcessor = movementProcessor;
        }

        public void Execute(string[] cmdTokens)
        {
            //TODO: validate input
            // get the first token. If should be the PLACE command 
            // the next token will be the X,Y,DIRECTION segment
            var positionTokens = cmdTokens[1].Split(',');
            
            // we should now have 3 tokens of X Y DIRECTION //TODO: verify
            var xPosition = int.Parse(positionTokens[0]);
            var yPosition = int.Parse(positionTokens[1]);
            var orientation = Enum.Parse<Orientation>(positionTokens[2]);
            var outcome = _movementProcessor.Place(xPosition, yPosition, orientation);
            _callStack.Push(new Call(this, outcome));
        }
    }
}
