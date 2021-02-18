using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingUkrTickets
{
    class JsonTrainWagonResponse
    {
        [JsonProperty(PropertyName = "data")]
        public DataWagon Data { get; set; }
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }
    }

    class DataWagon
    {
        [JsonProperty(PropertyName = "places")]
        public Places Places { get; set; }
        [JsonProperty(PropertyName = "schemeId")]
        public string SchemeId { get; set; }
        [JsonProperty(PropertyName = "reducedComfort")]
        public int ReducedComfort { get; set; }
    }

    class Places
    {
        [JsonProperty(PropertyName = "A")]
        public List<A> A { get; set; }
    }

    class A
    {
        [JsonProperty(PropertyName = "")]
        public int Value { get; set; }
    }
}
