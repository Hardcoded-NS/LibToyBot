using LibToyBot.Outcomes;
using LibToyBot.Spatial;
using Shouldly;
using TestStack.BDDfy;

namespace LibToyBot.FunctionalTest
{

    [Story(Title = "PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST")]
    public class PlaceRobotOnTableWithValidLocation : TestBase
    {
        private IOutcome moveOutcome;

        public void GivenTheRobotHasNotBeenPlacedOnTheTable()
        {
            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.HasRobotBeenPlaced.ShouldBeFalse();
        }

        public void WhenTheRobotReceivesAPlaceCommand()
        {
            moveOutcome = Robot.Action("PLACE 1,2,EAST");
        }

        public void ThenTheRobotIsPlacedOnTheTable()
        {
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            var positionReport = GetPositionReport();
            positionReport.ShouldNotBeNull();
            positionReport.Orientation.ShouldBe(Orientation.EAST);
            positionReport.PositionX.ShouldBe(1);
            positionReport.PositionY.ShouldBe(2);
            positionReport.HasRobotBeenPlaced.ShouldBeTrue();
        }

    }
}
