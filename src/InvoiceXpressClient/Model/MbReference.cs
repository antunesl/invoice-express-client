using Newtonsoft.Json;

namespace InvoiceXpress.Model
{
    public class MbReference
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }

}
