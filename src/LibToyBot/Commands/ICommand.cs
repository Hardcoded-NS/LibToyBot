namespace LibToyBot.Commands
{
    internal interface ICommand
    {
//        void Execute();
        void Execute(string[] cmdTokens = default);
    }
}
