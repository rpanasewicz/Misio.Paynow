namespace Misio.Paynow.Exceptions
{
    public class ValidationErrorException : PaynowException
    {
        public ValidationErrorException() : base(ErrorCodes.VALIDATION_ERROR, "Payment request was formulated incorrectly.")
        {
        }
    }
}