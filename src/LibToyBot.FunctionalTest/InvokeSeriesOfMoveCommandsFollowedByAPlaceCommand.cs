using LibToyBot.Outcomes;
using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "Any sequence of commands may be issued, in any order, including another PLACE command. ")]
    public class InvokeSeriesOfMoveCommandsFollowedByAPlaceCommand : TestBase
    {
        private IOutcome moveOutcome;
        
        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasBeenPlacedOnTheTable()
        {
            Robot.Action("PLACE 2,3,SOUTH");
        }

        public void WhenTheRobotReceivesAMoveCommand()
        {
            moveOutcome = Robot.Action(RobotCommands.Move);
        }


        public void AndWhenTheRobotReceivesATurnCommand()
        {
            moveOutcome = Robot.Action(RobotCommands.TurnLeft);
        }
        
        public void AndWhenTheRobotReceivesAMoveCommand()
        {
            moveOutcome = Robot.Action(RobotCommands.Move);
        }


        public void AndWhenTheRobotReceivesAPlaceCommand()
        {
            moveOutcome = Robot.Action("PLACE 4,4,WEST");
        }

        public void ThenTheRobotShouldBeAt4_4_West()
        {
            var positionReport = GetPositionReport();
            positionReport.Orientation.ShouldBe(Orientation.WEST);
            positionReport.PositionX.ShouldBe(4);
            positionReport.PositionY.ShouldBe(4);
        }

    }
}
