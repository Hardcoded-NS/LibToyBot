using LibToyBot.Outcomes;

namespace LibToyBot
{
    /// <summary>A Robot that can move around a scene.</summary>
    public class Robot
    {
        /// <summary>
        ///   <para>
        ///  Performs the specified action.
        /// </para>
        ///   <para>  Valid actions are 'PLACE X,Y,DIRECTION', 'MOVE', 'LEFT', 'RIGHT' and 'REPORT' </para>
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public ActionOutcome Action(string action)
        {
            //process moveCommand
            
            return new ActionOutcome
            {
                Result = OutomeStatus.Success
            };
        }
    }
}
