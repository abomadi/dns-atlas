using System;
using Newtonsoft.Json;

namespace HA.DNS.Models
{
    public class DnsRequest
    {
        public DnsRequest()
        {
        }
        [JsonRequired]
        [JsonProperty("x")]
        public double X { get; set; }
        [JsonRequired]
        [JsonProperty("y")]
        public double Y { get; set; }
        [JsonRequired]
        [JsonProperty("z")]
        public double Z { get; set; }
        [JsonRequired]
        [JsonProperty("vel")]
        public double Velocity { get; set; }
    }
}
