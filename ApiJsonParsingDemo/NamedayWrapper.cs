using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiJsonParsingDemo
{
    public class NamedayWrapper
    {
        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("nameday")]
        public Dictionary<string, string> Nameday { get; set; }
    }
}
