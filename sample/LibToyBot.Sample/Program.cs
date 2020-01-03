using System;
using LibToyBot.DependencyInjection;
using LibToyBot.Outcomes;
using Microsoft.Extensions.DependencyInjection;

namespace LibToyBot.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PlaceAndMoveRobot();
            PlaceAndMoveRobotWithOutcomes();
        }

        public static void PlaceAndMoveRobot()
        {
            var robot = GetRobot();
            robot.Action("PLACE 1,2,EAST");
            robot.Action("MOVE"); // 2,2,EAST
            robot.Action("LEFT"); // 2,2,NORTH
            robot.Action("MOVE"); // 2,3,NORTH
            robot.Action("MOVE"); // 2,4,NORTH
            IOutcome outcome = robot.Action("REPORT");
            Console.WriteLine($"Position: {outcome?.Message}"); // Print position & orientation
            Console.ReadKey();
        }

        public static void PlaceAndMoveRobotWithOutcomes()
        {
            var robot = GetRobot();
            IOutcome outcome = robot.Action("PLACE 4,2,EAST");
            Console.WriteLine(outcome.Message);
            outcome = robot.Action("MOVE"); // Can't move, it will fall off the table
            if (outcome.Result == OutcomeStatus.Fail)
            {
                Console.WriteLine(outcome.Message);
            }
            Console.ReadKey();
        }

        private static Robot GetRobot()
        {
            return new ServiceCollection()
                .AddRobot()
                .BuildServiceProvider()
                .GetService<Robot>();
        }
    }
}
