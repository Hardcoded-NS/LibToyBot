using LibToyBot.Outcomes;

namespace LibToyBot.Commands
{
    internal class Call
    {
        public ICommand Command { get; }
        public IOutcome Outcome { get; }

        public Call(ICommand command, IOutcome outcome)
        {
            Command = command;
            Outcome = outcome;
        }
    }
}
