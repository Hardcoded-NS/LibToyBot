using LibToyBot.Test.TestData;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class StatusReporterTest
    {
        private readonly StatusReporter statusReporter;
        private readonly IPositionTracker positionTracker;

        public StatusReporterTest()
        {
            positionTracker = new PositionTracker();
            statusReporter = new StatusReporter(positionTracker);
        }

        [Theory]
        [ClassData(typeof(MovementProcessorSuccessTestData))]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestStatusReport(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            positionTracker.SetPosition(xCoordinate, yCoordinate);
            positionTracker.SetOrientation(orientation);
            var report = statusReporter.Report();
            report.ToString().ShouldBe($"{xCoordinate},{yCoordinate},{orientation}");
        }
    }
}
