using System;
using System.Collections.Generic;

namespace Misio.Paynow.Models
{
    public class ErrorResponse
    {
        public string StatusCode { get; }
        public IEnumerable<Error> Errors { get; }

        public ErrorResponse(string statusCode, IEnumerable<Error> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public class Error
        {
            public string ErrorType { get; }
            public string Message { get; }

            public Error(string errorType, string message)
            {
                ErrorType = errorType;
                Message = message;
            }

            internal void Deconstruct(out string ErrorType, out string Message)
            {
                throw new NotImplementedException();
            }
        }
    }
}
