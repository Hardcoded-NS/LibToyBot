using System;
using LibToyBot.Reporting;
using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "REPORT will announce the X,Y and orientation of the robot")]
    public class RobotReportsItsPosition : TestBase
    {
        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasBeenPlacedOnTheTable()
        {
            Robot.Action("PLACE 2,3,EAST");
        }

        public void WhenTheRobotReportCommandIsInvoked()
        {
            Robot.Action(RobotCommands.Report);
        }

        public void Then_the_position_report_is_2_3_EAST()
        {
            var outcome = Robot.Action(RobotCommands.Report) as ReportOutcome;
            var positionReport = outcome?.PositionReport;
            positionReport.ShouldNotBeNull();
            outcome.Message.ShouldBe("2,3,EAST");
        }
    }
}
