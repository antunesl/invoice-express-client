using Newtonsoft.Json;

namespace InvoiceXpress.Model
{
    public class PreferredContact
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
