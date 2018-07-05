using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace InvoiceXpress.ApiClient
{
    public class InvoiceXpressClientFactory
    {
        public static InvoiceXpressClient Create(string apiBaseUrl, string apiKey, ILogger<InvoiceXpressClient> logger = null)
        {
            var apiBaseUri = new Uri(apiBaseUrl);
            return Create(apiBaseUri, apiKey, logger);
        }

        public static InvoiceXpressClient Create(Uri apiBaseUri, string apiKey, ILogger<InvoiceXpressClient> logger = null)
        {
            var clientLogger = logger ?? new NullLogger<InvoiceXpressClient>();
            var httpClient = new HttpClient
            {
                BaseAddress = apiBaseUri
            };

            var options = Options.Create(new InvoiceXpressClientOptions
            {
                ApiKey = apiKey
            });
            return new InvoiceXpressClient(httpClient, options, clientLogger);
        }
    }








}
