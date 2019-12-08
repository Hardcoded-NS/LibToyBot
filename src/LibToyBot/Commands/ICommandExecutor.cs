using LibToyBot.Outcomes;

namespace LibToyBot.Commands
{
    public interface ICommandExecutor
    {
        /// <summary>
        ///   <para>Parse and execute strings that contain commands</para>
        ///   <para>Available commands are:</para>
        ///   <para>PLACE X,Y,DIRECTION
        ///   MOVE
        ///   LEFT
        ///   RIGHT
        ///   REPORT
        ///   </para> 
        /// </summary>
        IOutcome ExecuteCommand(string commandText);
    }
}