using Misio.Paynow.Models;
using System;
using System.Linq;

namespace Misio.Paynow.Exceptions
{
    public class PaynowException : Exception
    {
        public string Code { get; }

        public PaynowException(string code, string message) : base(message)
        {
            Code = code;

        }

        public static PaynowException FromErrorResponse(ErrorResponse errorResponse)
        {
            (string ErrorType, string Message) = errorResponse.Errors.FirstOrDefault();

            return ErrorType switch
            {
                ErrorCodes.VALIDATION_ERROR => new ValidationErrorException(),
                ErrorCodes.UNAUTHORIZED => new UnauthorizedException(),
                ErrorCodes.VERIFICATION_FAILED => new VerificationFailedException(),
                ErrorCodes.NOT_FOUND => new NotFoundException(),
                ErrorCodes.PAYMENT_METHOD_NOT_AVAILABLE => new PaymentMethodNotAvailableException(),
                ErrorCodes.PAYMENT_AMOUNT_TOO_SMALL => new PaymentAmountTooSmallException(),
                ErrorCodes.PAYMENT_AMOUNT_TOO_LARGE => new PaymentAmountTooLargeException(),
                ErrorCodes.SYSTEM_TEMPORARILY_UNAVAILABLE => new SystemTemporarilyUnavailableException(),
                _ => new PaynowException(ErrorType, Message)
            };
        }
    }
}