using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(string message) : base(message)
        {
        }
    }
}
