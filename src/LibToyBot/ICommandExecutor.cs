using LibToyBot.Commands;

namespace LibToyBot
{
    internal interface ICommandExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}