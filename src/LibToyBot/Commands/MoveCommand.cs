using System;

namespace LibToyBot.Commands
{
    internal class MoveCommand : ICommand
    {
        private readonly IMovementProcessor _movementProcessor;

        public MoveCommand(IMovementProcessor movementProcessor)
        {
            _movementProcessor = movementProcessor;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
