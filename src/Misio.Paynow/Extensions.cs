using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Misio.Paynow
{
    public static class Extensions
    {
        private const string SANDBOX_URL = "https://api.sandbox.paynow.pl/v1/";
        private const string PRODUCTION_URL = "https://api.paynow.pl/v1/";

        public static IServiceCollection AddPaynowService(this IServiceCollection services, string apiKey, string signatureKey, string url)
        {
            var signatureKeyHash = new HMACSHA256(Encoding.UTF8.GetBytes(signatureKey));

            services.AddHttpClient("paynow", configure =>
            {
                configure.BaseAddress = new Uri(url);
                configure.DefaultRequestHeaders.Add("Api-Key", apiKey);

            });

            services.AddScoped<IPaynowService, PaynowService>(provider => new PaynowService(provider.GetRequiredService<IHttpClientFactory>(), signatureKeyHash));

            return services;
        }
    }
}
