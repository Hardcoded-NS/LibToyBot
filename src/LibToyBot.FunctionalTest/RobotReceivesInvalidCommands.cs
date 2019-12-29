using LibToyBot.Outcomes;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "The library should discard all invalid commands and parameters")]
    public class RobotReceivesInvalidCommands : TestBase
    {
        private IOutcome moveOutcome;

        public void GivenTheRobotIsReady()
        {
            Robot.ShouldNotBeNull();
        }

        public void WhenTheRobotReceivesAnInvalidCommand()
        {
            moveOutcome = Robot.Action("10 PRINT \"Hello world\"; 20 GOTO 10;");
        }

        public void ThenTheCommandIsDiscarded()
        {
            moveOutcome.Result.ShouldBe(OutcomeStatus.Fail);
            moveOutcome.Message.ShouldBe("The command is invalid");
        }

    }
}
