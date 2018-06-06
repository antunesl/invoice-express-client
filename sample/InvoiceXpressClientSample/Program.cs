using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvoiceXpressClientSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "19ef5d76ceb5e87b68a47923079f5752cacacf74";
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://testingapilda.app.invoicexpress.com/")
            };

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);


            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<InvoiceXpress.InvoiceClient>();

            Console.WriteLine("== InvoiceXpress Api Client ==");

            var invoiceClient = new InvoiceXpress.InvoiceClient(httpClient, apiKey, logger);

            //var invoice = await invoiceClient.Invoices.CreateInvoice(new InvoiceXpress.Model.Invoice
            //{
            //    Date = DateTimeOffset.Now.DateTime,
            //    DueDate = DateTimeOffset.Now.AddDays(2).DateTime,
            //    Client = new InvoiceXpress.Model.Client
            //    {
            //        Name = "John",
            //        Code = "100"
            //    },
            //    Items = new List<InvoiceXpress.Model.Item>
            //    {
            //        new InvoiceXpress.Model.Item { Name = "Product B", Description = "Cleaning product", UnitPrice = "10", Quantity = 2 }
            //    }
            //});
            //Console.WriteLine($"Created the invoice #{invoice.Id}: Created @ {invoice.Date}, with a total of {invoice.Total}{invoice.Currency}");


            var response = await invoiceClient.Invoices.GetAll("", "");
            foreach (var item in response.Invoices)
            {
                Console.WriteLine($"#{item.Id}: Created @ {item.Date}, with a total of {item.Total}{item.Currency} - Status: {item.Status}");
            }

            Console.WriteLine();
            Console.WriteLine("Press return to exit.");
            Console.ReadLine();
        }
    }
}
