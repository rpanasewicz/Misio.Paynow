namespace Misio.Paynow.Exceptions
{
    public class PaymentAmountTooSmallException : PaynowBaseException
    {
        public override string Code => "PAYMENT_AMOUNT_TOO_SMALL";

        public PaymentAmountTooSmallException() : base("Payment amount too small. Minimal amount of the payment should be greater than 1.00 PLN.")
        {
        }
    }
}