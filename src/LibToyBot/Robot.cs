using System;
using LibToyBot.Outcomes;

namespace LibToyBot
{
    /// <summary>A Robot that can move around a scene.</summary>
    public class Robot
    {
        private readonly ICommandParser _commandParser;
        private readonly IPositionReporter _positionReporter;

        //TODO: Look at dependency injection for all dependent services ?
        //That would require these internal components to be public
        public Robot()
        {
            //TODO: move position reporter to Command Executor?

            _commandParser = new CommandParser();
            _positionReporter = new PositionReporter(new PositionTracker());
        }


        /// <summary>
        ///   <para>
        ///  Performs the specified action.
        /// </para>
        ///   <para>  Valid actions are 'PLACE X,Y,DIRECTION', 'MOVE', 'LEFT', 'RIGHT' and 'REPORT' </para>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public IOutcome Action(string action)
        {
            //Get the requested command
            var command = _commandParser.Process(action);

            //Execute the command
            command.Execute();//There's currently no way to get the success/fail status of a command


            //This smells a bit funny. We're returning an action outcome without any way of knowing what the status of the command was.
            //Do we need to track command history (i.e. via CommandExecutor) and get the outcomes of commands from that?
            //NOTE that the spec does not mention nor require anything like this.
            //But I would imagine a consumer of this library needs some sort of feedback on the result of these commands.
            //Unless that feedback is via the position reporter..?
            //TODO: re-visit this
            return new ActionOutcome(OutcomeStatus.Success);
        }
    }
}
