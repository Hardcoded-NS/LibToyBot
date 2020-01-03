using LibToyBot.Outcomes;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "The library should discard all commands in the sequence until a valid PLACE command has been executed")]
    public class InvokeMoveCommandsBeforePlacingRobotOnTable : TestBase
    {
        private IOutcome moveOutcome;
        
        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void AndGivenTheRobotHasNotBeenPlacedOnTheTable()
        {
            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.HasRobotBeenPlaced.ShouldBeFalse();
        }

        public void WhenTheRobotReceivesAMoveCommand()
        {
            moveOutcome = Robot.Action(RobotCommands.Move);
        }

        public void ThenTheRobotIgnoresTheCommand()
        {
            moveOutcome.Result.ShouldBe(OutcomeStatus.Fail);
        }

    }
}
