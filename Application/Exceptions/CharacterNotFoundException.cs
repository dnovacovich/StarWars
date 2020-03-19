using System;

namespace Application.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(string message) : base(message)
        {
        }
    }
}
