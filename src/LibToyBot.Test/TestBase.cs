using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace LibToyBot.Test
{
    public abstract class TestBase
    {
        protected ServiceProvider serviceProvider;
        protected readonly ServiceCollection serviceCollection;

        protected TestBase()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<Robot>()
                .AddScoped<ICommandExecutor, CommandExecutor>()
                .AddScoped<IPositionTracker, PositionTracker>()
                .AddScoped<IPositionReporter, PositionReporter>()
                .AddScoped<IMovementProcessor, MovementProcessor>()
                .AddScoped<IBoundsEvaluator, BoundsEvaluator>()
                .AddSingleton<Table>();
        }

        internal void BuildServices()
        {
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public T SubstituteFor<T>() where T : class
        {
            var mock = Substitute.For<T>();
            serviceCollection.AddScoped<T>(provider => mock);
            return mock;
        }
    }
}
