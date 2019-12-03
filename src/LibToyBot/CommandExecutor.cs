using System;
using System.Linq;
using LibToyBot.Commands;
using LibToyBot.Outcomes;

namespace LibToyBot
{
    /// <summary>A parser for processing string input and converting to a command</summary>
    internal class CommandExecutor : ICommandExecutor
    {
        private readonly IMovementProcessor _movementProcessor;

        public CommandExecutor(IMovementProcessor movementProcessor)
        {
            _movementProcessor = movementProcessor;
        }
        /// <summary>
        ///   <para>Parse and execute strings that contain commands. Returns an ICommand instance of the corresponding command</para>
        ///   <para>Available commands are:</para>
        ///   <para>PLACE X,Y,DIRECTION
        ///   MOVE
        ///   LEFT
        ///   RIGHT
        ///   REPORT
        ///   </para> 
        /// </summary>
        public IOutcome ExecuteCommand(string commandText)
        {
            //TODO: this needs a Call Stack that is passed to the Command.
            // Command puts it's outcome on the call stack 
            // TODO: sanitise input

            // tokenize the command string on whitespace
            var cmdTokens = commandText.Split(' ');

            // switch over the first token
            var firstToken = cmdTokens.FirstOrDefault();
            Enum.TryParse<RobotCommand>(firstToken, out var commandEnum);// let the switch expression deal with throwing exceptions
            ICommand command = commandEnum switch
            {
                //TODO: This design is wrong.
                //Suggest implementing CommandExecutor and passing MovementProcessor as argument to Execute()
                RobotCommand.PLACE => new PlaceCommand(cmdTokens, _movementProcessor),
                RobotCommand.MOVE => new MoveCommand(_movementProcessor),
                RobotCommand.LEFT => new TurnCommand(cmdTokens, _movementProcessor),
                RobotCommand.RIGHT => new TurnCommand(cmdTokens, _movementProcessor),
                RobotCommand.REPORT => new ReportCommand(),
                _ => throw new ArgumentOutOfRangeException()
            };
            command.Execute();
            //TODO: Get 
            return null;
        }
    }
}