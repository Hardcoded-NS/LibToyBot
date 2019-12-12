using LibToyBot.Outcomes;
using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "Any movement that would result in this must be prevented, however further valid movement commands must still be allowed")]
    public class RobotIsPreventedFromMovingOffTable : TestBase
    {
        private IOutcome moveOutcome;

        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasBeenPlacedOnTheEdgeOfTheTable()
        {
            Robot.Action("PLACE 0,0,SOUTH");
        }

        public void WhenTheRobotReceivesAMoveCommand()
        {
            moveOutcome = Robot.Action(RobotCommands.Move);
        }

        public void ThenTheRobotIsPreventedFromFallingOffTheTable()
        {
            moveOutcome.Result.ShouldBe(OutcomeStatus.Fail);
            moveOutcome.Message.ShouldBe("The new position 0, -1 would make the robot fall off the table");
        }

        public void AndThenTheRobotHasNotMovedPosition()
        {
            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.Orientation.ShouldBe(Orientation.SOUTH);
            positionReport.PositionX.ShouldBe(0);
            positionReport.PositionY.ShouldBe(0);
            positionReport.ToString().ShouldBe("0,0,SOUTH");
        }


        public void AndThenTheRobotCanContinueToMove()
        {
            Robot.Action(RobotCommands.TurnLeft);
            Robot.Action(RobotCommands.TurnLeft);
            Robot.Action(RobotCommands.Move);
            Robot.Action(RobotCommands.Move);

            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.Orientation.ShouldBe(Orientation.NORTH);
            positionReport.PositionX.ShouldBe(0);
            positionReport.PositionY.ShouldBe(2);
            positionReport.ToString().ShouldBe("0,2,NORTH");
        }

    }
}
