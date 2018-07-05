# InvoiceXpress API Client 

[![Build status](https://ci.appveyor.com/api/projects/status/nxyu6ufnf6h73q3g?svg=true)](https://ci.appveyor.com/project/antunesl/invoicexpress-client) [![NuGet](https://img.shields.io/nuget/v/InvoiceXpress.ApiClient.svg?)](https://www.nuget.org/packages/InvoiceXpress.ApiClient/) [![NuGet](https://img.shields.io/nuget/dt/InvoiceXpress.ApiClient.svg)](https://www.nuget.org/packages/InvoiceXpress.ApiClient/) 

API Client for [InvoiceXpress API](https://developers.invoicexpress.com/docs/versions/2.0.0)

***

## Usage

**IHttpClientFactory Patern**

```csharp
var apiKey = "<api-key>";
var apiUrl = "https://<api-url>";

services.AddInvoiceXpressClient(options =>
{
    options.ApiKey = apiKey;
    options.ApiBaseUrl = apiUrl;
});
```

**Client Factory**

```csharp
var apiKey = "<api-key>";
var apiUrl = "https://<api-url>";

var invoiceClient = InvoiceXpressClientFactory.Create(apiUrl, apiKey, logger);
```


## Development

```

```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)