using LibToyBot.Outcomes;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "The PLACE command should be discarded if it places the robot outside of the table surface")]
    public class PlaceRobotOnTableWithInvalidOrientation : TestBase
    {
        private IOutcome moveOutcome;

        public void GivenTheRobotHasNotBeenPlacedOnTheTable()
        {
            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.HasRobotBeenPlaced.ShouldBeFalse();
        }

        public void WhenTheRobotReceivesAPlaceCommandWithOutOfBoundsPosition()
        {
            moveOutcome = Robot.Action("PLACE 1,4,UPWARDS");
        }

        public void ThenThePlaceCommandIsIgnored()
        {
            moveOutcome.Result.ShouldBe(OutcomeStatus.Fail);
            moveOutcome.Message.ShouldBe("The command input is invalid");
        }

    }
}
