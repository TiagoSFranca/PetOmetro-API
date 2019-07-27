using System;

namespace PetOmetro.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        { }
    }
}
