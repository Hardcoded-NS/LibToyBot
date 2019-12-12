using LibToyBot.Outcomes;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "The PLACE command should be discarded if it places the robot outside of the table surface")]
    public class PlaceRobotOnTableWithInvalidLocation : TestBase
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
            moveOutcome = Robot.Action("PLACE 1,7,EAST");
        }

        public void ThenThePlaceCommandIsIgnored()
        {
            moveOutcome.Result.ShouldBe(OutcomeStatus.Fail);
            moveOutcome.Message.ShouldBe("The position 1, 7 would place the robot off the table");
        }

    }
}
