using System;
using System.Collections.Generic;
using System.Text;

namespace LibToyBot.Exceptions
{
    public class InvalidSceneRangeException : Exception
    {
        public InvalidSceneRangeException(string message) : base(message)
        {
        }
    }
}
