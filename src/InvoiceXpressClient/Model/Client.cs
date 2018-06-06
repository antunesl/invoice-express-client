using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceXpress.Model
{
    public class Client
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]   
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("fiscal_id")]
        public string FiscalId { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("preferred_contact")]
        public PreferredContact PreferredContact { get; set; }

        [JsonProperty("observations")]
        public string Observations { get; set; }

        [JsonProperty("open_account_link")]
        public string OpenAccountLink { get; set; }

        [JsonProperty("send_options")]
        public string SendOptions { get; set; }

        [JsonProperty("payment_days")]
        public string PaymentDays { get; set; }

        [JsonProperty("tax_exemption_code")]
        public string TaxExemptionCode { get; set; }



        public static Client FromJson(string json) => JsonConvert.DeserializeObject<Client>(json, Converter.Settings);
    }
}
