using System;
using System.Collections.Generic;

namespace PetOmetro.Application.Exceptions
{
    public class ResponseError
    {
        public ResponseError(Exception exception)
        {
            Message = exception.Message;

        }

        public string Message { get; private set; }
    }

    public class ResponseNotFound : ResponseError
    {
        public ResponseNotFound(Exception exception) : base(exception)
        {
        }
    }

    public class ResponseBadRequest : ResponseError
    {
        public ResponseBadRequest(Exception exception) : base(exception)
        {
            StackTrace = exception.StackTrace;
            if (exception is ValidationException validationException)
                Failures = validationException.Failures;
        }

        public string StackTrace { get; private set; }
        public IDictionary<string, string[]> Failures { get; private set; }
    }

    public class ResponseInternalServerError : ResponseError
    {
        public ResponseInternalServerError(Exception exception) : base(exception)
        {
            StackTrace = exception.StackTrace;
        }

        public string StackTrace { get; private set; }
    }

    public class ResponseUnauthorized : ResponseError
    {
        public ResponseUnauthorized(Exception exception) : base(exception)
        {
        }
    }
}
