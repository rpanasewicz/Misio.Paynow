using Misio.Paynow.Exceptions;
using Misio.Paynow.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Misio.Paynow
{
    internal class PaynowService : IPaynowService
    {
        private readonly HttpClient _http;

        public PaynowService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("paynow");
        }

        public async Task<PaymentStatusRequestResponse> GetPeymentStatus(string paymentId, CancellationToken cancellationToken = default)
        {
            var response = await _http.GetAsync($"payments/{paymentId}/status", cancellationToken);
            return await HandleResponse<PaymentStatusRequestResponse>(response, cancellationToken);
        }

        public async Task<PaymentRequestResponse> NewPayment(PaymentRequest request, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("payments", content, cancellationToken);
            return await HandleResponse<PaymentRequestResponse>(response, cancellationToken);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await JsonSerializer.DeserializeAsync<T>(contentStream, cancellationToken: cancellationToken);
            }

            var errorResponse = await JsonSerializer.DeserializeAsync<ErrorResponse>(contentStream, cancellationToken: cancellationToken);

            throw PaynowException.FromErrorResponse(errorResponse);
        }
    }
}