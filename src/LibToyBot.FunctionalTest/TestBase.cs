using LibToyBot.DependencyInjection;
using LibToyBot.Reporting;
using Microsoft.Extensions.DependencyInjection;
using TestStack.BDDfy;
using TestStack.BDDfy.Xunit;

namespace LibToyBot.FunctionalTest
{
    /// <summary>A base class for unit tests that implements a service provider for Dependency Injection resolution of the system under test</summary>
    public abstract class TestBase
    {
        protected readonly Robot Robot;
        protected ServiceProvider serviceProvider;
        protected readonly ServiceCollection serviceCollection;

        protected TestBase()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddRobot(); 
            serviceProvider = serviceCollection.BuildServiceProvider();
            Robot = serviceProvider.GetService<Robot>();
        }

        protected PositionReport GetPositionReport()
        {
            var outcome = Robot.Action(RobotCommands.Report) as ReportOutcome;
            return outcome?.PositionReport;
        }

        [BddfyFact]
        public void Execute()
        {
            this.BDDfy(GetType().Name);
        }
    }
}
