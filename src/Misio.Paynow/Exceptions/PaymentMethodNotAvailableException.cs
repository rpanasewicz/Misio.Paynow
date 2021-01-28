namespace Misio.Paynow.Exceptions
{
    public class PaymentMethodNotAvailableException : PaynowBaseException
    {
        public override string Code => "PAYMENT_METHOD_NOT_AVAILABLE";

        public PaymentMethodNotAvailableException() : base("Chosen payment method is not available.")
        {
        }
    }
}