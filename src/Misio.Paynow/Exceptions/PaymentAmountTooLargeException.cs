namespace Misio.Paynow.Exceptions
{
    public class PaymentAmountTooLargeException : PaynowException
    {
        public PaymentAmountTooLargeException() : base(ErrorCodes.PAYMENT_AMOUNT_TOO_LARGE, "Maximum amount of the payment is too large.")
        {
        }
    }
}