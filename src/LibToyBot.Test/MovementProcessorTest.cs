using LibToyBot.Movement;
using LibToyBot.Outcomes;
using LibToyBot.Test.TestData;
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
    public class MovementProcessorTest
    {
        private readonly MovementProcessor movementProcessor;
        private readonly BoundsEvaluator boundsEvaluator;
        private readonly PositionTracker positionTracker;

        public MovementProcessorTest()
        {
            //TODO: dependency injection?
            boundsEvaluator = new BoundsEvaluator(new Table());
            positionTracker = new PositionTracker();
            movementProcessor = new MovementProcessor(boundsEvaluator, positionTracker);
        }


        [Theory]
        [ClassData(typeof(MovementProcessorSuccessTestData))]
        public void TestSuccessfulMove(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            positionTracker.SetPosition(xCoordinate, yCoordinate);
            positionTracker.SetOrientation(orientation);
            var outcome = movementProcessor.Move();
            outcome.Result.ShouldBe(OutcomeStatus.Success);
        }

        [Theory]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestFailedEdgeMove(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            positionTracker.SetPosition(xCoordinate, yCoordinate);
            positionTracker.SetOrientation(orientation);
            var outcome = movementProcessor.Move();
            outcome.Result.ShouldBe(OutcomeStatus.Fail);
        }




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
