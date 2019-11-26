using System;
using System.Windows.Input;
using LibToyBot.Commands;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
 
    public class CmdParserTest
    {
        internal CmdParser Parser { get; set; }

        public CmdParserTest()
        {
            Parser = new CmdParser();
        }

        [Fact]
        public void TestCmdParserConstructor()
        {
            var parser = new CmdParser();
            parser.ShouldNotBeNull();
        }

        [Theory]
        [InlineData("PLACE X,Y,DIRECTION", typeof(PlaceCommand))]
        [InlineData("MOVE", typeof(MoveCommand))]
        [InlineData("LEFT", typeof(TurnCommand))]
        [InlineData("RIGHT", typeof(TurnCommand))]
        [InlineData("REPORT", typeof(ReportCommand))]
        public void TestProcessReturnTypes(string commandText, Type expectedType)
        {
            ICommand command = Parser.Process(commandText);
            command.ShouldNotBeNull();
            command.ShouldBeOfType(expectedType);
        }
    }
}
