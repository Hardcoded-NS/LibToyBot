using LibToyBot.Outcomes;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class RobotTest : TestBase
    {
        private readonly Robot _robot;

        public RobotTest()
        {


            _robot = serviceProvider.GetService<Robot>();
        }

        [Fact]
        public void TestRobotPlace()
        {
            var moveOutcome = _robot.Action("PLACE 1,2,NORTH");
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
        }


        [Fact]
        public void TestRobotMove()
        {
            var moveOutcome = _robot.Action("MOVE");
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
        }
    }

}
