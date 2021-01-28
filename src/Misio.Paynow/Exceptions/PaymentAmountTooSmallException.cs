namespace Misio.Paynow.Exceptions
{
    public class PaymentAmountTooSmallException : PaynowException
    {
        public PaymentAmountTooSmallException() : base(ErrorCodes.PAYMENT_AMOUNT_TOO_SMALL, "Payment amount too small. Minimal amount of the payment should be greater than 1.00 PLN.")
        {
        }
    }
}