using System;
using System.Collections.Generic;
using System.Linq;
using LibToyBot.Commands;
using LibToyBot.Movement;
using LibToyBot.Outcomes;
using LibToyBot.Reporting;

namespace LibToyBot
{
    /// <summary>A parser for processing string input and converting to a command</summary>
    internal class CommandExecutor : ICommandExecutor
    {
        private readonly IMovementProcessor _movementProcessor;
        private readonly Stack<Call> _callStack;

        public CommandExecutor(IMovementProcessor movementProcessor)
        {
            _movementProcessor = movementProcessor;
            _callStack = new Stack<Call>();
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
            // TODO: sanitise input

            // tokenize the command string on whitespace
            var cmdTokens = commandText.Split(' ');

            // switch over the first token
            var firstToken = cmdTokens.FirstOrDefault();
            Enum.TryParse<RobotCommand>(firstToken, out var commandEnum);

            //TODO: Move this to a .NET Core class library
            // introduce DI 
            // add CommandMap to map RobotCommands to instances of ICommand
            ICommand command = commandEnum switch
            {
                RobotCommand.PLACE => new PlaceCommand(cmdTokens, _callStack, _movementProcessor),
                RobotCommand.MOVE => new MoveCommand(_callStack, _movementProcessor),
                RobotCommand.LEFT => new TurnCommand(_callStack, cmdTokens, _movementProcessor),
                RobotCommand.RIGHT => new TurnCommand(_callStack, cmdTokens, _movementProcessor),
                RobotCommand.REPORT => new ReportCommand(_callStack),
                _ => throw new ArgumentOutOfRangeException()
            };

            command.Execute();
            //TODO: Get 
            return null;
        }
    }
}