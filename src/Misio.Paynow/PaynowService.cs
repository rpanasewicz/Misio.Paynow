using Misio.Paynow.Exceptions;
using Misio.Paynow.Models;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Misio.Paynow
{
    internal class PaynowService : IPaynowService
    {
        private readonly HttpClient _http;
        private readonly HMACSHA256 _signatureKey;

        public PaynowService(IHttpClientFactory httpClientFactory, HMACSHA256 signatureKey)
        {
            _http = httpClientFactory.CreateClient("paynow");
            _signatureKey = signatureKey;
        }

        public async Task<PaymentStatusRequestResponse> GetPeymentStatus(string paymentId, CancellationToken cancellationToken = default)
        {
            var response = await _http.GetAsync($"payments/{paymentId}/status", cancellationToken);
            return await HandleResponse<PaymentStatusRequestResponse>(response, cancellationToken);
        }

        public async Task<PaymentRequestResponse> NewPayment(PaymentRequest request, CancellationToken cancellationToken = default)
        {
            var idempotencyKey = Guid.NewGuid().ToString("N");

            var requestString = JsonSerializer.Serialize(request);
            var requestHash = calculateHMAC(requestString);

            var content = new StringContent(requestString, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "payments");
            requestMessage.Headers.Add("Signature", requestHash);
            requestMessage.Headers.Add("Idempotency-Key", idempotencyKey);

            var response = await _http.SendAsync(requestMessage, cancellationToken);
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

        private string calculateHMAC(string data)
        {
            byte[] hashmessage = _signatureKey.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hashmessage);
        }
    }
}