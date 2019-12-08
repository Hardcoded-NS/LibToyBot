using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Movement
{
    internal class PlaceCommand : ICommand
    {
        private readonly string[] _cmdTokens;
        private readonly IMovementProcessor _movementProcessor;

        public PlaceCommand(string[] cmdTokens, Stack<Call> callStack, IMovementProcessor movementProcessor)
        {
            _cmdTokens = cmdTokens;
            _movementProcessor = movementProcessor;
        }

        public void Execute()
        {
            //TODO: validate input
            // get the first token. If should be the PLACE command 
            // the next token will be the X,Y,DIRECTION segment
            var positionTokens = _cmdTokens[1].Split(',');
            
            // we should now have 3 tokens of X Y DIRECTION //TODO: verify
            var xPosition = int.Parse(positionTokens[0]);
            var yPosition = int.Parse(positionTokens[1]);
            var orientation = Enum.Parse<Orientation>(positionTokens[2]);
            var outcome = _movementProcessor.Place(xPosition, yPosition, orientation);
            //TODO: something with outome?
        }
    }
}
