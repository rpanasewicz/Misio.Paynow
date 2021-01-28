using Microsoft.AspNetCore.Http;
using Misio.Paynow.Exceptions;
using Misio.Paynow.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Misio.Paynow
{
    public interface IPaynowService
    {
        Task<PaymentRequestResponse> NewPaymentRequest(PaymentRequest request, CancellationToken cancellationToken = default);
        void GetPeymentStatus();
    }

    internal class PaynowService : IPaynowService
    {
        private readonly HttpClient _http;
        
        public PaynowService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("paynow");
        }

        public void GetPeymentStatus()
        {
            throw new System.NotImplementedException();
        }

        public async Task<PaymentRequestResponse> NewPaymentRequest(PaymentRequest request, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("payments", content, cancellationToken);

            var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await JsonSerializer.DeserializeAsync<PaymentRequestResponse>(contentStream, cancellationToken: cancellationToken);
            }

            var errorResponse = await JsonSerializer.DeserializeAsync<ErrorResponse>(contentStream, cancellationToken: cancellationToken);

            throw PaynowBaseException.MapFromCode(errorResponse.Errors.FirstOrDefault()?.ErrorType);
        }
    }
}