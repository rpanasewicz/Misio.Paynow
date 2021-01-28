namespace Misio.Paynow.Exceptions
{
    public class ValidationErrorException : PaynowBaseException
    {
        public override string Code => "VALIDATION_ERROR";

        public ValidationErrorException() : base("Payment request was formulated incorrectly.")
        {
        }
    }
}