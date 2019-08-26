using System;

namespace PetOmetro.Identity.Exceptions
{
    public class PasswordException : Exception
    {
        public PasswordException(string message)
            : base(message)
        { }
    }
}
