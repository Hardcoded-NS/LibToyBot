using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class PositionTrackerTest
    {
        private readonly PositionTracker positionTracker;

        public PositionTrackerTest()
        {
            positionTracker = new PositionTracker();
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        [InlineData(-2, -3)]
        public void TestTrackPosition(int xPos, int yPos)
        {
            positionTracker.SetPosition(xPos, yPos);
            (int x, int y) = positionTracker.GetPosition();
            x.ShouldBe(xPos);
            y.ShouldBe(yPos);
        }

        [Theory]
        [InlineData(Orientation.North)]
        [InlineData(Orientation.South)]
        [InlineData(Orientation.East)]
        [InlineData(Orientation.West)]
        public void TestOrientation(Orientation newOrientation)
        {
            positionTracker.SetOrientation(newOrientation);
            Orientation currentOrientation = positionTracker.GetOrientation();
            currentOrientation.ShouldBe(newOrientation);
        }

    }

}
