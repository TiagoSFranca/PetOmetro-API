using System;

namespace PetOmetro.Application.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
            : base("Acesso não autorizado.")
        { }

        public AuthorizationException(string message)
            : base(message)
        { }
    }
}
