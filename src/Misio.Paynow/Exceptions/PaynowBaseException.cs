using System;

namespace Misio.Paynow.Exceptions
{
    public abstract class PaynowBaseException : Exception
    {
        public abstract string Code { get; }

        public PaynowBaseException(string message) : base(message)
        {
        }

        public static PaynowBaseException MapFromCode(string code)
        {
            return code switch
            {
                "PAYMENT_METHOD_NOT_AVAILABLE" => new PaymentMethodNotAvailableException(),
                "PAYMENT_AMOUNT_TOO_SMALL" => new PaymentAmountTooSmallException(),
                "PAYMENT_AMOUNT_TOO_LARGE" => new PaymentAmountTooLargeException(),
                "SYSTEM_TEMPORARILY_UNAVAILABLE" => new SystemTemporarilyUnavailableException(),
                "VERIFICATION_FAILED" => new VerificationFailedException(),
                "NOT_FOUND" => new NotFoundException(),
                "UNAUTHORIZED" => new UnauthorizedException(),
                "VALIDATION_ERROR" => new ValidationErrorException(),
                _ => new UnknowErrorException()
            };
        }
    }
}