namespace Misio.Paynow.Exceptions
{
    public class PaymentMethodNotAvailableException : PaynowException
    {
        public PaymentMethodNotAvailableException() : base(ErrorCodes.PAYMENT_METHOD_NOT_AVAILABLE, "Chosen payment method is not available.")
        {
        }
    }
}