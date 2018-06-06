using Newtonsoft.Json;

namespace InvoiceXpress.Model
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("unit_price")]
        public string UnitPrice { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("quantity")]
        public double? Quantity { get; set; }

        [JsonProperty("tax")]
        public Tax Tax { get; set; }

        [JsonProperty("discount")]
        public long? Discount { get; set; }

        [JsonProperty("subtotal")]
        public double? Subtotal { get; set; }

        [JsonProperty("tax_amount")]
        public double? TaxAmount { get; set; }

        [JsonProperty("discount_amount")]
        public long? DiscountAmount { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }



        public static Item FromJson(string json) => JsonConvert.DeserializeObject<Item>(json, Converter.Settings);
    }
}
