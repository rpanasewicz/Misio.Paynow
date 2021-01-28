namespace Misio.Paynow.Models
{
    public class PaymentRequestResponse
    {
        public string RedirectUrl { get; }
        public string PaymentId { get; }
        public PaymentStatus Status { get; }

        public PaymentRequestResponse(string redirectUrl, string paymentId, string status)
        {
            RedirectUrl = redirectUrl;
            PaymentId = paymentId;
            Status = PaymentStatus.Parse(status);
        }
    }
}
