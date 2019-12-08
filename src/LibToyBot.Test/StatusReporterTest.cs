using LibToyBot.Test.TestData;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class PositionReporterTest
    {
        private readonly PositionReporter PositionReporter;
        private readonly IPositionTracker positionTracker;

        public PositionReporterTest()
        {
            positionTracker = new PositionTracker();
            PositionReporter = new PositionReporter(positionTracker);
        }

        [Theory]
        [ClassData(typeof(MovementProcessorSuccessTestData))]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestPositionReport(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            positionTracker.SetPosition(xCoordinate, yCoordinate);
            positionTracker.SetOrientation(orientation);
            var report = PositionReporter.Report();
            report.ToString().ShouldBe($"{xCoordinate},{yCoordinate},{orientation}");
        }
    }
}
