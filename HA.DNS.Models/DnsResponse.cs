using System;
using Newtonsoft.Json;

namespace HA.DNS.Models
{
    public class DnsResponse
    {
        public DnsResponse(double location)
        {
            Loc = location;
        }
        [JsonProperty("loc")]
        public double Loc { get; set; }
    }
}
