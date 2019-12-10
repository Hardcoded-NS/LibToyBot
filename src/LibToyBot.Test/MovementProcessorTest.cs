using System;
using LibToyBot.Movement;
using LibToyBot.Outcomes;
using LibToyBot.Spatial;
using LibToyBot.Test.TestData;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    /**
                            N
           +------+------+------+------+------+
           |      |      |      |      |      |
           |      |      |      |      |      |
           +----------------------------------+
           |      |      |      |      |      |
           |      |      |      |      |      |
         W +----------------------------------+ E
           |      |      |      |      |      |
           |      |      |      |      |      |
           +----------------------------------+
           |      |      |      |      |      |
           |      |      |      |      |      |
           +------+------+------+------+------+
           |      |      |      |      |      |
           |      |      |      |      |      |
           +------+------+------+------+------+
        0,0                 S

    */
    public class MovementProcessorTest : TestBase
    {
        private readonly IMovementProcessor _movementProcessor;
        private readonly IPositionTracker _positionTracker;

        public MovementProcessorTest()
        {
            BuildServices();
            _movementProcessor = serviceProvider.GetService<IMovementProcessor>();
            _positionTracker = serviceProvider.GetService<IPositionTracker>();
        }


        [Theory]
        [ClassData(typeof(MovementProcessorSuccessTestData))]
        public void TestSuccessfulMove(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            _positionTracker.SetPosition(xCoordinate, yCoordinate);
            _positionTracker.SetOrientation(orientation);
            var outcome = _movementProcessor.Move();
            outcome.Result.ShouldBe(OutcomeStatus.Success);
        }

        [Theory]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestFailedEdgeMove(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            _positionTracker.SetPosition(xCoordinate, yCoordinate);
            _positionTracker.SetOrientation(orientation);
            var outcome = _movementProcessor.Move();
            outcome.Result.ShouldBe(OutcomeStatus.Fail);
        }



        [Theory]
        [InlineData(-1, 2, Orientation.NORTH)]
        [InlineData(6, 6, Orientation.SOUTH)]
        [InlineData(2, 7, Orientation.WEST)]
        [InlineData(2, -6, Orientation.EAST)]
        public void TestOutOfBoundsPlaceCommand(int xPos, int yPos, Orientation orientation)
        {
            var outcome = _movementProcessor.Place(xPos, yPos, orientation);
            outcome.Result.ShouldBe(OutcomeStatus.Fail);
        }

        [Theory]
        [InlineData(Orientation.NORTH, Direction.LEFT, Orientation.WEST)] 
        [InlineData(Orientation.SOUTH, Direction.LEFT, Orientation.EAST)]
        [InlineData(Orientation.EAST, Direction.RIGHT, Orientation.SOUTH)]
        [InlineData(Orientation.WEST, Direction.RIGHT, Orientation.NORTH)]
        public void TestTurnAction(Orientation startingOrientation, Direction direction, Orientation expectedOrientation)
        {
            _positionTracker.SetOrientation(startingOrientation);
            var outcome = _movementProcessor.Turn(direction);
            outcome.Result.ShouldBe(OutcomeStatus.Success);
            var newOrientation = _positionTracker.GetOrientation();
            newOrientation.ShouldBe(expectedOrientation);
        }

    }
}
