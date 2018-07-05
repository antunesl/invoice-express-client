using Newtonsoft.Json;

namespace InvoiceXpress.ApiClient.Model
{
    public partial class GeneratePdfResponse
    {
        [JsonProperty("output")]
        public PdfDocument Document { get; set; }
    }

    public class PdfDocument
    {
        [JsonProperty("pdfUrl")]
        public string PdfUrl { get; set; }
    }
}
