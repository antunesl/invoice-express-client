using InvoiceXpressApiClient.Controllers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceXpress
{
    public class InvoiceClient
    {
        private readonly string _apiKey;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        private bool HasLogger => _logger != null;


        public InvoicesController Invoices { get; set; }



        public InvoiceClient(HttpClient httpClient, string apiKey, ILogger<InvoiceClient> logger)
        {
            _apiKey = apiKey;
            _logger = logger;
            _httpClient = httpClient;

            Invoices = new InvoicesController(_httpClient, apiKey, logger);
        }




       



    }
}


