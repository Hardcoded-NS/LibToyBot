using System;
using System.Collections.Generic;
using LibToyBot.Commands;
using LibToyBot.Outcomes;
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
            try
            {
                ProcessCommand(cmdTokens);
            }
            catch (Exception)
            {
                var failedOutcome = new ActionOutcome(OutcomeStatus.Fail, "The command input is invalid");
                _callStack.Push(new Call(this, failedOutcome));
            }
        }

        private void ProcessCommand(string[] cmdTokens)
        {
            // if we don't have exactly 2 command tokens, then the command input was invalid
            if (cmdTokens.Length != 2) throw new Exception();

            // get the first token. If should be the PLACE command 
            // the next token will be the X,Y,DIRECTION segment
            var positionTokens = cmdTokens[1].Split(',');

            // if we don't have exactly 3 position tokens, then the command input was invalid
            if (positionTokens.Length != 3) throw new Exception();

            // we should now have 3 tokens of X Y DIRECTION
            var xPosition = int.Parse(positionTokens[0]);
            var yPosition = int.Parse(positionTokens[1]);
            var orientation = Enum.Parse<Orientation>(positionTokens[2]);

            var outcome = _movementProcessor.Place(xPosition, yPosition, orientation);
            _callStack.Push(new Call(this, outcome));
        }
    }
}
