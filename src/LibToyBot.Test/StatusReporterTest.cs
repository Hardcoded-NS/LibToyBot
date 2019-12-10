using LibToyBot.Reporting;
using LibToyBot.Spatial;
using LibToyBot.Test.TestData;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class PositionReporterTest : TestBase
    {
        private readonly IPositionReporter positionReporter;
        private readonly IPositionTracker positionTracker;

        public PositionReporterTest()
        {
            BuildServices();
            positionTracker = serviceProvider.GetService<IPositionTracker>();
            positionReporter = serviceProvider.GetService<IPositionReporter>();
        }

        [Theory]
        [ClassData(typeof(MovementProcessorSuccessTestData))]
        [ClassData(typeof(MovementProcessorBoundaryTestData))]
        public void TestPositionReport(int xCoordinate, int yCoordinate, Orientation orientation)
        {
            positionTracker.SetPosition(xCoordinate, yCoordinate);
            positionTracker.SetOrientation(orientation);
            var report = positionReporter.Report();
            report.ToString().ShouldBe($"{xCoordinate},{yCoordinate},{orientation}");
        }
    }
}
