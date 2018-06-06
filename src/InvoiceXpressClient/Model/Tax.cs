using Newtonsoft.Json;

namespace InvoiceXpress.Model
{
    public class Tax
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("default_tax")]
        public long DefaultTax { get; set; }


        public static Tax FromJson(string json) => JsonConvert.DeserializeObject<Tax>(json, Converter.Settings);
    }
}
