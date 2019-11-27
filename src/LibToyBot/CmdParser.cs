using System;
using System.Linq;
using LibToyBot.Commands;

namespace LibToyBot
{

    /// <summary>A parser for processing string input and converting to a command</summary>
    internal class CmdParser
    {
        //TODO: Constructor for service injection

        /// <summary>
        ///   <para>Parse strings that contain commands. Returns an ICommand instance of the corresponding command</para>
        ///   <para>Available commands are:</para>
        ///   <para>PLACE X,Y,DIRECTION
        ///   MOVE
        ///   LEFT
        ///   RIGHT
        ///   REPORT
        ///   </para> 
        /// </summary>
        public ICommand Process(string commandText)
        {
            // TODO: sanitise input

            // tokenize the command string on whitespace
            var cmdTokens = commandText.Split(' ');

            // switch over the first token
            var firstToken = cmdTokens.FirstOrDefault();
            Enum.TryParse<RobotCommand>(firstToken, out var commandEnum);// let the switch expression deal with throwing exceptions
            return commandEnum switch
            {
                RobotCommand.PLACE => new PlaceCommand(cmdTokens),
                RobotCommand.MOVE => new MoveCommand(),
                RobotCommand.LEFT => new TurnCommand(cmdTokens),
                RobotCommand.RIGHT => new TurnCommand(cmdTokens),
                RobotCommand.REPORT => new ReportCommand(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    internal enum RobotCommand
    {
        PLACE,
        MOVE,
        LEFT,
        RIGHT,
        REPORT
    }
}
