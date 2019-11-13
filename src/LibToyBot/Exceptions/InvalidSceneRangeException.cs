using System;

namespace LibToyBot.Exceptions
{
    public class InvalidTableRangeException : Exception
    {
        public InvalidTableRangeException(string message) : base(message)
        {
        }
    }
}
