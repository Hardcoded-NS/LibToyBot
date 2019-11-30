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
        public void TestSuccessfulMove(int x, int y, Orientation orientation)
        {
            positionTracker.SetPosition(x, y);
            positionTracker.SetOrientation(orientation);
            MoveOutcome outcome = movementProcessor.Move();
            outcome.Result.ShouldBe(OutomeStatus.Success);
        }

        [Theory]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestFailedEdgeMove(int x, int y, Orientation orientation)
        {
            positionTracker.SetPosition(x, y);
            positionTracker.SetOrientation(orientation);
            MoveOutcome outcome = movementProcessor.Move();
            outcome.Result.ShouldBe(OutomeStatus.Fail);
        }

    }
}
