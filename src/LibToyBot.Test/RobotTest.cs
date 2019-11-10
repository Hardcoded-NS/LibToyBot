using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class RobotTest
    {

        [Fact]
        public void TestRobotConstructor()
        {
            var robot = new Robot();
        }

        [Fact]
        public void TestRobotPlace()
        {
            var robot = new Robot();
            var moveOutcome = robot.Action("PLACE X,Y,DIRECTION");
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Success.ShouldBeTrue();
        }

        [Fact]
        public void TestRobotMove()
        {
            var robot = new Robot();
            var moveOutcome = robot.Action("MOVE");
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Success.ShouldBeTrue();
        }
    }

}
