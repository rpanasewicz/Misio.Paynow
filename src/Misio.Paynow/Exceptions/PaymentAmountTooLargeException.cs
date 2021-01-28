namespace Misio.Paynow.Exceptions
{
    public class PaymentAmountTooLargeException : PaynowBaseException
    {
        public override string Code => "PAYMENT_AMOUNT_TOO_LARGE";

        public PaymentAmountTooLargeException() : base("Maximum amount of the payment is too large.")
        {
        }
    }
}