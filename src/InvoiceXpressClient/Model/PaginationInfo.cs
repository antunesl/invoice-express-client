using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceXpressApiClient.Model
{
    public class PaginationInfo
    { 
        [JsonProperty("total_entries")]
        public long TotalEntries { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }
    }
}
