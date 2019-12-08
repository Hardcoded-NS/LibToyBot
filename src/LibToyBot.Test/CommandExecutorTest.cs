using LibToyBot.Commands;
using LibToyBot.Movement;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace LibToyBot.Test
{
 
    public class CommandExecutorTest : TestBase
    {
        private readonly ICommandExecutor _executor;
        private readonly IMovementProcessor _mockMovementProcessor;

        public CommandExecutorTest()
        {
            _mockMovementProcessor = SubstituteFor<IMovementProcessor>();
            BuildServices();
            _executor = serviceProvider.GetService<ICommandExecutor>(); 
        }
        
        [Theory]
        [InlineData("PLACE 1,2,NORTH", 1, 2, Orientation.NORTH)]
        [InlineData("PLACE 0,0,EAST", 0, 0, Orientation.EAST)]
        [InlineData("PLACE 5,5,SOUTH", 5, 5, Orientation.SOUTH)]
        [InlineData("PLACE 3,3,WEST", 3, 3, Orientation.WEST)]
        public void TestSuccessfulPlaceCommand(string commandText, int xPos, int yPos, Orientation orientation)
        {
            _executor.ExecuteCommand(commandText);
            _mockMovementProcessor.Received().Place(xPos, yPos, orientation);
        }

        //TODO: Move, Turn and Report Tests

// TODO: These tests belong in the MovementProcessor test case
//        [Theory]
//        [InlineData("PLACE -1,2,NORTH", -1, 2, Orientation.NORTH)]
//        [InlineData("PLACE 6,6,SOUTH", 6, 6, Orientation.SOUTH)]
//        [InlineData("PLACE 2,7,SOUTH", 2, 7, Orientation.WEST)]
//        [InlineData("PLACE 2,-6,SOUTH", 2, -6, Orientation.EAST)]
////        [InlineData("PLACE a,b,WEST", 3, 3, Orientation.WEST)]
//        public void TestOutOfBoundsPlaceCommand(string commandText, int xPos, int yPos, Orientation orientation)
//        {
//            _executor.ExecuteCommand(commandText);
//            _mockMovementProcessor.DidNotReceive().Place(xPos, yPos, orientation);
//        }

    }
}
