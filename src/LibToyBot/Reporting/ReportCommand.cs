using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Reporting
{
    internal class ReportCommand : ICommand
    {
        private readonly Stack<Call> _callStack;
        private readonly IPositionReporter _positionReporter;

        public ReportCommand(Stack<Call> callStack, IPositionReporter positionReporter)
        {
            _callStack = callStack;
            _positionReporter = positionReporter;
        }

        public void Execute(string[] cmdTokens = default)
        {
            var postionReport = _positionReporter.Report();
        }
    }
}
