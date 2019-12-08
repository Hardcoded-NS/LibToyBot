using LibToyBot.Commands;
using LibToyBot.Movement;
using LibToyBot.Reporting;
using Microsoft.Extensions.DependencyInjection;

namespace LibToyBot.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddRobot(this ServiceCollection serviceCollection)
        {
            //TODO: Verify these internal implementation classes
            serviceCollection
                .AddSingleton<Robot>()
                .AddScoped<ICommandExecutor, CommandExecutor>()
                .AddScoped<IPositionTracker, PositionTracker>()
                .AddScoped<IPositionReporter, PositionReporter>()
                .AddScoped<IMovementProcessor, MovementProcessor>()
                .AddScoped<IBoundsEvaluator, BoundsEvaluator>()
                .AddSingleton<Table>();
            return serviceCollection;
        }
    }
}
