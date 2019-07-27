using System;
using System.Collections.Generic;

namespace PetOmetro.Application.Exceptions
{
    public class ResponseErrorViewModel
    {
        public ResponseErrorViewModel(Exception exception)
        {
            Message = exception.Message;

        }

        public string Message { get; private set; }
    }

    public class ResponseNotFoundViewModel : ResponseErrorViewModel
    {
        public ResponseNotFoundViewModel(Exception exception) : base(exception)
        {
        }
    }

    public class ResponseBadRequestViewModel : ResponseErrorViewModel
    {
        public ResponseBadRequestViewModel(Exception exception) : base(exception)
        {
            StackTrace = exception.StackTrace;
            if (exception is ValidationException validationException)
                Failures = validationException.Failures;
        }

        public string StackTrace { get; private set; }
        public IDictionary<string, string[]> Failures { get; private set; }
    }

    public class ResponseInternalServerErrorViewModel : ResponseErrorViewModel
    {
        public ResponseInternalServerErrorViewModel(Exception exception) : base(exception)
        {
            StackTrace = exception.StackTrace;
        }

        public string StackTrace { get; private set; }
    }
}
