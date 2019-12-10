using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Movement
{
    internal class PlaceCommand : ICommand
    {
        private readonly IMovementProcessor _movementProcessor;

        public PlaceCommand(Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
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
            //TODO: Check if the position is in bounds?
            var outcome = _movementProcessor.Place(xPosition, yPosition, orientation);
            //TODO: something with outome?
        }
    }
}
