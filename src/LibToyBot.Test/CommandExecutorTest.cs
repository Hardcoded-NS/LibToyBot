using System;
using LibToyBot.Commands;
using LibToyBot.Movement;
using LibToyBot.Reporting;
using LibToyBot.Spatial;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace LibToyBot.Test
{
 
    public class CommandExecutorTest : TestBase
    {
        private readonly ICommandExecutor _executor;
        private readonly IMovementProcessor _mockMovementProcessor;
        private readonly IPositionReporter _mockPositionReporter;

        public CommandExecutorTest()
        {
            _mockMovementProcessor = SubstituteFor<IMovementProcessor>();
            _mockPositionReporter = SubstituteFor<IPositionReporter>();
            BuildServices();
            _executor = serviceProvider.GetService<ICommandExecutor>(); 
        }
        
        [Theory]
        [InlineData("PLACE 1,2,NORTH", 1, 2, Orientation.NORTH)]
        [InlineData("PLACE 0,0,EAST", 0, 0, Orientation.EAST)]
        [InlineData("PLACE 5,5,SOUTH", 5, 5, Orientation.SOUTH)]
        [InlineData("PLACE 3,3,WEST", 3, 3, Orientation.WEST)]
        public void TestPlaceCommand(string commandText, int xPos, int yPos, Orientation orientation)
        {
            _executor.ExecuteCommand(commandText);
            _mockMovementProcessor.Received().Place(xPos, yPos, orientation);
        }


        [Theory]
        [InlineData("MOVE")]
        public void TestMoveCommand(string commandText)
        {
            _executor.ExecuteCommand(commandText);
            _mockMovementProcessor.Received().Move();
        }

        [Theory]
        [InlineData("LEFT")]
        [InlineData("RIGHT")]
        public void TestTurnCommand(string commandText)
        {
            _executor.ExecuteCommand(commandText);
            var direction = Enum.Parse<Direction>(commandText);
            _mockMovementProcessor.Received().Turn(direction);
        }

        [Theory]
        [InlineData("REPORT")]
        public void TestReportCommand(string commandText)
        {
            _executor.ExecuteCommand(commandText);
            _mockPositionReporter.Received().Report();
        }
    }
}
