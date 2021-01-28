namespace Misio.Paynow.Models
{
    public class PaymentRequestResponse
    {
        public string RedirectUrl { get; }
        public string PaymentId { get; }
        public string Status { get; }
    }
}
