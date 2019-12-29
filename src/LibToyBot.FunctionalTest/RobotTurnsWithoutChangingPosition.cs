using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot")]
    public class RobotTurnsWithoutChangingPosition : TestBase
    {
        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasBeenPlacedOnTheEdgeOfTheTable()
        {
            Robot.Action("PLACE 0,0,NORTH");
        }

        public void WhenTheRobotTurnsLeft()
        {
            Robot.Action(RobotCommands.TurnLeft);
        }

        public void ThenTheRobotIsFacingWest()
        {
            var positionReport = GetPositionReport();
            positionReport.Orientation.ShouldBe(Orientation.WEST);
        }

        public void AndThenTheRobotHasNotChangedPosition()
        {
            var positionReport = GetPositionReport();
            positionReport.PositionX.ShouldBe(0);
            positionReport.PositionY.ShouldBe(0);
        }

    }
}
