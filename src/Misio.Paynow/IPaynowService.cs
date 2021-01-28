using Misio.Paynow.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Misio.Paynow
{
    public interface IPaynowService
    {
        Task<PaymentRequestResponse> NewPayment(PaymentRequest request, CancellationToken cancellationToken = default);
        Task<PaymentStatusRequestResponse> GetPeymentStatus(string paymentId, CancellationToken cancellationToken = default);
    }
}