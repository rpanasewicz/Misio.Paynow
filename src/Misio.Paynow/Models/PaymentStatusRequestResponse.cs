namespace Misio.Paynow.Models
{
    public class PaymentStatusRequestResponse
    {
        public string PaymentId { get; }
        public PaymentStatus Status { get; }

        public PaymentStatusRequestResponse(string paymentId, string status)
        {
            PaymentId = paymentId;
            Status = PaymentStatus.Parse(status);
        }
    }
}
