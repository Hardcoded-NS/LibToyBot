using Microsoft.Extensions.DependencyInjection;

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
    }
}
