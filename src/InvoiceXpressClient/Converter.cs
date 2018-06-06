using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace InvoiceXpress
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTime,
            DateFormatString = "dd/MM/yyyy",
            NullValueHandling = NullValueHandling.Ignore,
            //Converters = {
            //    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            //},
        };
    }
}
