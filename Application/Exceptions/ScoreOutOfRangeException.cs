using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ScoreOutOfRangeException : Exception
    {
        public ScoreOutOfRangeException(string message) : base(message)
        {
        }
    }
}
