using LibToyBot.Outcomes;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class RobotTest
    {
        private readonly Robot _robot;

        public RobotTest()
        {
            _robot = new Robot();
        }

        [Fact]
        public void TestRobotPlace()
        {
            var moveOutcome = _robot.Action("PLACE 1,2,NORTH");
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            var positionReport = _robot.Action("REPORT");
            positionReport.ShouldBeOfType<ReportOutcome>();
        }


        [Fact]
        public void TestRobotMove()
        {
            var robot = new Robot();
            var moveOutcome = robot.Action("MOVE");
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
        }
    }

}
