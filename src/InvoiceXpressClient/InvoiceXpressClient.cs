using InvoiceXpressApiClient.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace InvoiceXpress
{
    public class InvoiceXpressClient : IInvoiceXpressApi
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        private bool HasLogger => _logger != null;


        public InvoicesController Invoices { get; set; }

        public string ApiUrl => _apiUrl;


        public InvoiceXpressClient(HttpClient httpClient, IOptions<InvoiceXpressClientOptions> options, ILogger<InvoiceXpressClient> logger)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _apiUrl = options.Value.ApiBaseUrl;
            _apiKey = options.Value.ApiKey;
            _logger = logger;
            _httpClient = httpClient;

            Invoices = new InvoicesController(_httpClient, _apiKey, _logger);
        }

    }


    public class InvoiceXpressClientOptions
    {
        public string ApiKey { get; set; }
        public string ApiBaseUrl { get; set; }
    }


    public interface IInvoiceXpressApi
    {

    }
}


