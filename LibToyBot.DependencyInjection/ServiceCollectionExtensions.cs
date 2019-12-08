using System.Collections.Generic;
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
                .AddSingleton<Stack<Call>>()
                .AddSingleton<PlaceCommand>()
                .AddSingleton<MoveCommand>()
                .AddSingleton<TurnCommand>()
                .AddSingleton<ReportCommand>()
                .AddSingleton<Table>();




//            serviceCollection.AddSingleton<IDictionary<RobotCommand, ICommand>>(provider =>
//            {
//                IDictionary<RobotCommand, ICommand> commandMap = new Dictionary<RobotCommand, ICommand>(5)
//                {
//                    {RobotCommand.PLACE, new PlaceCommand()}
//                };
//
//                return commandMap;
//            });



            return serviceCollection;
        }
    }
}
