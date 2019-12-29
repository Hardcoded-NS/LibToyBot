using LibToyBot.Outcomes;
using LibToyBot.Reporting;
using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "Any sequence of commands may be issued, in any order")]
    public class InvokeSeriesOfMoveCommands : TestBase
    {
        private IOutcome moveOutcome;
        
        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasBeenPlacedOnTheTable()
        {
            Robot.Action("PLACE 0,0,EAST");
        }

        public void WhenTheRobotMovesForwardOneSpace()
        {
            moveOutcome = Robot.Action(RobotCommands.Move); //1,0,EAST
        }


        public void AndWhenTheRobotTurnsToTheLeft()
        {
            moveOutcome = Robot.Action(RobotCommands.TurnLeft); //1,0,NORTH
        }
        
        public void AndWhenTheRobotMovesForwardFourSpaces()
        {
            moveOutcome = Robot.Action(RobotCommands.Move); //1,1,NORTH
            moveOutcome = Robot.Action(RobotCommands.Move); //1,2,NORTH
            moveOutcome = Robot.Action(RobotCommands.Move); //1,3,NORTH
            moveOutcome = Robot.Action(RobotCommands.Move); //1,4,NORTH
        }

        public void AndWhenTheRobotTurnsToTheRight()
        {
            moveOutcome = Robot.Action(RobotCommands.TurnRight); //1,4,EAST
        }
        
        public void AndWhenTheRobotMovesForwardThreeSpaces()
        {
            moveOutcome = Robot.Action(RobotCommands.Move); //1,4,EAST
            moveOutcome = Robot.Action(RobotCommands.Move); //2,4,EAST
            moveOutcome = Robot.Action(RobotCommands.Move); //3,4,EAST
        }

        public void Then_the_robot_should_be_at_4_4_EAST()
        {
            var outcome = Robot.Action(RobotCommands.Report) as ReportOutcome;
            outcome.ShouldNotBeNull();
            outcome.Message.ShouldBe("4,4,EAST");

            var positionReport = outcome?.PositionReport;
            positionReport.Orientation.ShouldBe(Orientation.EAST);
            positionReport.PositionX.ShouldBe(4);
            positionReport.PositionY.ShouldBe(4);
        }


    }
}
