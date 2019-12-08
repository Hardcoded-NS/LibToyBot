using LibToyBot.Outcomes;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class RobotTest : TestBase
    {
        private readonly Robot _robot;
        private readonly ICommandExecutor _mockExecutor;

        public RobotTest()
        {
            //setup mocks here
            _mockExecutor = SubstituteFor<ICommandExecutor>(); 
            BuildServices();
            _robot = serviceProvider.GetService<Robot>(); //TODO: Maybe provide this via test fixture?
        }

        [Fact]
        public void TestRobotPlace()
        {
            const string cmd = "PLACE 1,2,NORTH";
            var moveOutcome = _robot.Action(cmd);
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            _mockExecutor.Received().ExecuteCommand(cmd);
        }

        [Fact]
        public void TestRobotMove()
        {
            const string cmd = "MOVE";
            var moveOutcome = _robot.Action(cmd);
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            _mockExecutor.Received().ExecuteCommand(cmd);
        }

        [Fact]
        public void TestRobotTurnLeft()
        {
            const string cmd = "LEFT";
            var moveOutcome = _robot.Action(cmd);
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            _mockExecutor.Received().ExecuteCommand(cmd);
        }

        [Fact]
        public void TestRobotTurnRight()
        {
            const string cmd = "RIGHT";
            var moveOutcome = _robot.Action(cmd);
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            _mockExecutor.Received().ExecuteCommand(cmd);
        }

        [Fact]
        public void TestRobotReport()
        {
            const string cmd = "REPORT";
            var moveOutcome = _robot.Action(cmd);
            moveOutcome.ShouldNotBeNull();
            moveOutcome.Result.ShouldBe(OutcomeStatus.Success);
            _mockExecutor.Received().ExecuteCommand(cmd);
        }
    }

}
