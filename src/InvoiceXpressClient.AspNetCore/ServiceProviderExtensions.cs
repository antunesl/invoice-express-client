using InvoiceXpress;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static void AddInvoiceXpressClient(this IServiceCollection services, Action<InvoiceXpressClientOptions> options)
        {
            var defaultOptions = new InvoiceXpressClientOptions();
            options?.Invoke(defaultOptions);

            services.Configure(options);

            services.AddHttpClient<InvoiceXpressClient>(clientOptions =>
            {
                clientOptions.BaseAddress = new Uri(defaultOptions.ApiBaseUrl);
            });
        }
    }
}
