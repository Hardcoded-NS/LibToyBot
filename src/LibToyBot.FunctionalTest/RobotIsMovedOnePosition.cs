using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "MOVE will move the toy robot one unit forward in the direction it is currently facing")]
    public class RobotIsMovedOnePosition : TestBase
    {
        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasBeenPlacedOnTheEdgeOfTheTable()
        {
            Robot.Action("PLACE 0,0,NORTH");
        }

        public void WhenTheRobotMoveOneSpace()
        {
            Robot.Action(RobotCommands.Move);
        }

        public void ThenTheRobotIsAt_0_1_NORTH()
        {
            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.Orientation.ShouldBe(Orientation.NORTH);
            positionReport.PositionX.ShouldBe(0);
            positionReport.PositionY.ShouldBe(1);
        }

    }
}
