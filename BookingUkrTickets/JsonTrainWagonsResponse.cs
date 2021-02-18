using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingUkrTickets
{
    class JsonTrainWagonsResponse
    {
        [JsonProperty(PropertyName = "data")]
        public DataWagons Data { get; set; }
    }

    class DataWagons
    {
        [JsonProperty(PropertyName = "types")]
        public List<TypesWagons> Types { get; set; }
        [JsonProperty(PropertyName = "wagons")]
        public List<Wagons> Data { get; set; }
    }

    class TypesWagons
    {
        [JsonProperty(PropertyName = "type_id")]
        public string TypeId { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "letter")]
        public string Letter { get; set; }
        [JsonProperty(PropertyName = "free")]
        public int Free { get; set; }
        [JsonProperty(PropertyName = "cost")]
        public int Cost { get; set; }
        [JsonProperty(PropertyName = "isOneCost")]
        public int isOneCost { get; set; }
        
    }

    class Wagons
    {
        [JsonProperty(PropertyName = "num")]
        public int Num { get; set; }
        [JsonProperty(PropertyName = "type_id")]
        public string TypeId { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "class")]
        public string Class { get; set; }
        [JsonProperty(PropertyName = "railway")]
        public int Railway { get; set; }
        [JsonProperty(PropertyName = "free")]
        public int Free { get; set; }
        [JsonProperty(PropertyName = "byWishes")]
        public bool ByWishes { get; set; }
        [JsonProperty(PropertyName = "hasBedding")]
        public bool HasBedding { get; set; }
        [JsonProperty(PropertyName = "obligatoryBedding")]
        public bool ObligatoryBedding { get; set; }
        [JsonProperty(PropertyName = "services")]
        public List Services { get; set; }
        [JsonProperty(PropertyName = "prices")]
        public Prices Prices { get; set; }
        [JsonProperty(PropertyName = "reservePrice")]
        public int ReserverPrice { get; set; }
        [JsonProperty(PropertyName = "allowBonus")]
        public bool AllowBonus { get; set; }
        [JsonProperty(PropertyName = "air")]
        public bool Air { get; set; }
    }

    class Prices
    {
        [JsonProperty(PropertyName = "А")]
        public int A { get; set; }
        [JsonProperty(PropertyName = "Б")]
        public int B { get; set; }
    }
}
