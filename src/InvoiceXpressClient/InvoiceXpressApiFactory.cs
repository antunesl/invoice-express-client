using Microsoft.Extensions.DependencyInjection;
using System;

namespace InvoiceXpress.ApiClient
{
    public interface IInvoiceXpressApiFactory
    {
        IInvoiceXpressApi GetConfigurationService();
    }

    public class InvoiceXpressApiFactory : IInvoiceXpressApiFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public InvoiceXpressApiFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IInvoiceXpressApi GetConfigurationService()
        {
            return _serviceProvider.GetRequiredService<IInvoiceXpressApi>();
        }
    }
}
