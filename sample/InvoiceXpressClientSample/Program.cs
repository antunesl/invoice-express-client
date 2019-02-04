using InvoiceXpress;
using InvoiceXpress.ApiClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InvoiceXpressClientSample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var apiKey = configuration["InvoiceXpressApiKey"];
            var apiUrl = configuration["InvoiceXpressApiUrl"];


            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);


            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<InvoiceXpressClient>();

            Console.WriteLine("== InvoiceXpress Api Client ==");

            // Creating the client
            var invoiceClient = InvoiceXpressClientFactory.Create(apiUrl, apiKey, logger);


            var response = await invoiceClient.Invoices.GetAll();
            if (response.Pagination != null)
            {
                Console.WriteLine($"Page {response.Pagination.CurrentPage}/{response.Pagination.TotalPages} | Total: {response.Pagination.TotalEntries}");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }

            foreach (var item in response.Invoices)
            {
                Console.WriteLine($" > #{item.Id} [{item.Status}]: Invoice for '{item.Client?.Name}' created @ {item.Date}, with a total of {item.Total}{item.Currency}");
            }

            Console.WriteLine();
            Console.WriteLine("Press return to exit.");
            Console.ReadLine();
        }
    }
}
