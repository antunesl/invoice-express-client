using InvoiceXpress.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceXpressApiClient.Controllers
{
    public class BaseController
    {
        private readonly string _apiKey;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;


        public BaseController(HttpClient httpClient, string apiKey, ILogger logger)
        {
            _apiKey = apiKey;
            _logger = logger;
            _httpClient = httpClient;
        }


        protected async Task<T> GetAsync<T>(string url, bool throwOnError = false)
        {
            var response = await _httpClient.GetAsync(AddApiKeyToUrl(url));

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("The GET request to '{url}' was not successful ({statusCode})", url, response.StatusCode);
                if (throwOnError)
                    throw new Exception();
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnObj = JsonConvert.DeserializeObject<T>(responseContent);

            return returnObj;
        }


        protected async Task<T> PostAsync<T>(string url, object request, bool throwOnError = false)
        {
            var jsonContent = JsonConvert.SerializeObject(request, InvoiceXpress.Converter.Settings);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(AddApiKeyToUrl(url), httpContent);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("The POST request to '{url}' was not successful ({statusCode})", url, response.StatusCode);
                if (throwOnError)
                    throw new Exception();
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnObj = JsonConvert.DeserializeObject<T>(responseContent);

            return returnObj;
        }


        //protected async Task ValidateResponse(HttpResponseMessage response)
        //{
        //    if (response.IsSuccessStatusCode)
        //        return;

        //    switch (response.StatusCode)
        //    {
        //        case System.Net.HttpStatusCode.Accepted:
        //            break;
        //        case System.Net.HttpStatusCode.Ambiguous:
        //            break;
        //        case System.Net.HttpStatusCode.BadGateway:
        //            break;
        //        case System.Net.HttpStatusCode.BadRequest:
        //            break;
        //        case System.Net.HttpStatusCode.Conflict:
        //            break;
        //        case System.Net.HttpStatusCode.Continue:
        //            break;
        //        case System.Net.HttpStatusCode.Created:
        //            break;
        //        case System.Net.HttpStatusCode.ExpectationFailed:
        //            break;
        //        case System.Net.HttpStatusCode.Forbidden:
        //            break;
        //        case System.Net.HttpStatusCode.Found:
        //            break;
        //        case System.Net.HttpStatusCode.GatewayTimeout:
        //            break;
        //        case System.Net.HttpStatusCode.Gone:
        //            break;
        //        case System.Net.HttpStatusCode.HttpVersionNotSupported:
        //            break;
        //        case System.Net.HttpStatusCode.InternalServerError:
        //            break;
        //        case System.Net.HttpStatusCode.LengthRequired:
        //            break;
        //        case System.Net.HttpStatusCode.MethodNotAllowed:
        //            break;
        //        case System.Net.HttpStatusCode.Moved:
        //            break;
        //        //case System.Net.HttpStatusCode.MovedPermanently:
        //        //    break;
        //        //case System.Net.HttpStatusCode.MultipleChoices:
        //        //    break;
        //        case System.Net.HttpStatusCode.NoContent:
        //            break;
        //        case System.Net.HttpStatusCode.NonAuthoritativeInformation:
        //            break;
        //        case System.Net.HttpStatusCode.NotAcceptable:
        //            break;
        //        case System.Net.HttpStatusCode.NotFound:
        //            _logger.LogWarning("NOT FOUND");
        //            break;
        //        case System.Net.HttpStatusCode.NotImplemented:
        //            break;
        //        case System.Net.HttpStatusCode.NotModified:
        //            break;
        //        case System.Net.HttpStatusCode.OK:
        //            break;
        //        case System.Net.HttpStatusCode.PartialContent:
        //            break;
        //        case System.Net.HttpStatusCode.PaymentRequired:
        //            break;
        //        case System.Net.HttpStatusCode.PreconditionFailed:
        //            break;
        //        case System.Net.HttpStatusCode.ProxyAuthenticationRequired:
        //            break;
        //        //case System.Net.HttpStatusCode.Redirect:
        //        //    break;
        //        case System.Net.HttpStatusCode.RedirectKeepVerb:
        //            break;
        //        case System.Net.HttpStatusCode.RedirectMethod:
        //            break;
        //        case System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
        //            break;
        //        case System.Net.HttpStatusCode.RequestEntityTooLarge:
        //            break;
        //        case System.Net.HttpStatusCode.RequestTimeout:
        //            break;
        //        case System.Net.HttpStatusCode.RequestUriTooLong:
        //            break;
        //        case System.Net.HttpStatusCode.ResetContent:
        //            break;
        //        //case System.Net.HttpStatusCode.SeeOther:
        //        //    break;
        //        case System.Net.HttpStatusCode.ServiceUnavailable:
        //            break;
        //        case System.Net.HttpStatusCode.SwitchingProtocols:
        //            break;
        //        //case System.Net.HttpStatusCode.TemporaryRedirect:
        //        //    break;
        //        case System.Net.HttpStatusCode.Unauthorized:
        //            _logger.LogWarning("ACCESS DENIED: The API Key parameter is missing or is incorrectly entered");
        //            break;
        //        case System.Net.HttpStatusCode.UnsupportedMediaType:
        //            break;
        //        case System.Net.HttpStatusCode.Unused:
        //            break;
        //        case System.Net.HttpStatusCode.UpgradeRequired:
        //            break;
        //        case System.Net.HttpStatusCode.UseProxy:
        //            break;
        //        default:
        //            break;
        //    }

        //}


        private string AddApiKeyToUrl(string url)
        {
            return $"{url}?api_key={_apiKey}";
        }
    }
}
