using LibToyBot.Commands;

namespace LibToyBot
{
    internal interface ICommandParser
    {
        /// <summary>
        ///   <para>Parse strings that contain commands. Returns an ICommand instance of the corresponding command</para>
        ///   <para>Available commands are:</para>
        ///   <para>PLACE X,Y,DIRECTION
        ///   MOVE
        ///   LEFT
        ///   RIGHT
        ///   REPORT
        ///   </para> 
        /// </summary>
        ICommand Process(string commandText);
    }
}