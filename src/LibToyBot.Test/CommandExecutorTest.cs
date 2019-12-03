using System;
using LibToyBot.Commands;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
 
    public class CommandExecutorTest
    {
        internal CommandExecutor Executor { get; set; }

        public CommandExecutorTest()
        {
            //TODO: figure out these nested dependencies
            //TODO: Mock these dependencies
            Executor = new CommandExecutor(new MovementProcessor(new BoundsEvaluator(new Table()), new PositionTracker()));
        }
        
//        [Theory]
//        [InlineData("PLACE X,Y,DIRECTION", typeof(PlaceCommand))]
//        [InlineData("MOVE", typeof(MoveCommand))]
//        [InlineData("LEFT", typeof(TurnCommand))]
//        [InlineData("RIGHT", typeof(TurnCommand))]
//        [InlineData("REPORT", typeof(ReportCommand))]
//        public void TestProcessReturnTypes(string commandText, Type expectedType)
//        {
//            ICommand command = Executor.ExecuteCommand(commandText);
//            command.ShouldNotBeNull();
//            command.ShouldBeOfType(expectedType);

//        }
    }
}
