using System.Security.Cryptography.X509Certificates;
using LibToyBot.Commands;
using LibToyBot.Outcomes;

namespace LibToyBot
{
    /// <summary>A Robot that can move around a table.</summary>
    public class Robot
    {
        private readonly ICommandExecutor _commandExecutor;

        public Robot(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        /// <summary>
        ///   <para>
        /// Performs the specified action.
        /// </para>
        ///   <para>  Valid actions are 'PLACE X,Y,DIRECTION', 'MOVE', 'LEFT', 'RIGHT' and 'REPORT' </para>
        /// </summary>
        /// <param name="action">The action to perform</param>
        /// <returns>Returns an outcome of the action</returns>
        public IOutcome Action(string action)
        {
            //Execute the requested command and return the outcome
            return _commandExecutor.ExecuteCommand(action);
        }
    }

}
