using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InvoiceXpress.Model
{
    public class Invoice
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sequence_number")]
        public string SequenceNumber { get; set; }

        [JsonProperty("inverted_sequence_number")]
        public string InvertedSequenceNumber { get; set; }

        [JsonProperty("sequence_id")]
        public string SequenceId { get; set; }

        [JsonProperty("tax_exemption")]
        public string TaxExemption { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("observations")]
        public string Observations { get; set; }

        [JsonProperty("retention")]
        public string Retention { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("saft_hash")]
        public string SaftHash { get; set; }

        [JsonProperty("sum")]
        public decimal? Sum { get; set; }

        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        [JsonProperty("before_taxes")]
        public decimal? BeforeTaxes { get; set; }

        [JsonProperty("taxes")]
        public decimal? Taxes { get; set; }

        [JsonProperty("total")]
        public decimal? Total { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("mb_reference")]
        public MbReference MbReference { get; set; }






        public static Invoice FromJson(string json) => JsonConvert.DeserializeObject<Invoice>(json, Converter.Settings);
    }
}
