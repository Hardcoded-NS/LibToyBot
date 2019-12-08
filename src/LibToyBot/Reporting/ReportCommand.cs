using System;
using System.Collections.Generic;
using LibToyBot.Commands;

namespace LibToyBot.Reporting
{
    internal class ReportCommand : ICommand
    {
        private readonly Stack<Call> _callStack;

        public ReportCommand(Stack<Call> callStack)
        {
            _callStack = callStack;
        }

        public void Execute(string[] cmdTokens = default)
        {
            throw new NotImplementedException();
        }
    }
}
