﻿using System.Collections.Generic;

namespace Misio.Paynow.Models
{
    public class ErrorResponse
    {
        public string StatusCode { get; }
        public IEnumerable<Error> Errors { get; }

        public class Error
        {
            public string ErrorType { get; }
            public string Message { get; }
        }
    }
}