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
            MoveOutcome outcome = movementProcessor.Move();
            outcome.Result.ShouldBe(OutomeStatus.Success);
        }

        [Theory]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestFailedEdgeMove(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            positionTracker.SetPosition(xCoordinate, yCoordinate);
            positionTracker.SetOrientation(orientation);
            MoveOutcome outcome = movementProcessor.Move();
            outcome.Result.ShouldBe(OutomeStatus.Fail);
        }

    }
}
