using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingUkrTickets
{
    class JsonTrainSearchResponse
    {
        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }


        [JsonProperty(PropertyName = "error")]
        public int Error { get; set; }
        [JsonProperty(PropertyName = "captcha")]
        public string Captcha { get; set; }

    }

    class Data
    {
        [JsonProperty(PropertyName = "warning")]
        public string Warning { get; set; }
        [JsonProperty(PropertyName = "list")]
        public List<List> List { get; set; }
    }

    class User
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "studentNumber")]
        public string StudentNumber { get; set; }
        [JsonProperty(PropertyName = "privilegeCategory")]
        public string PrivilegeCategory { get; set; }
        [JsonProperty(PropertyName = "privilegeDocument")]
        public string PrivilegeDocument { get; set; }
        [JsonProperty(PropertyName = "authToken")]
        public List AuthToken { get; set; }
    }

    class List
    {
        [JsonProperty(PropertyName = "num")]
        public string Num { get; set; }
        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }
        [JsonProperty(PropertyName = "isTransformer")]
        public int IsTransformer { get; set; }
        [JsonProperty(PropertyName = "travelTime")]
        public DateTime TravelTime { get; set; }
        [JsonProperty(PropertyName = "from")]
        public From From { get; set; }
        [JsonProperty(PropertyName = "to")]
        public To To { get; set; }
        [JsonProperty(PropertyName = "types")]
        public List<Types> Types { get; set; }
        [JsonProperty(PropertyName = "child")]
        public Child Child { get; set; }
        [JsonProperty(PropertyName = "allowStudent")]
        public int AllowStudent { get; set; }
        [JsonProperty(PropertyName = "allowBooking")]
        public int AllowBooking { get; set; }
        [JsonProperty(PropertyName = "icCis")]
        public int IsCis { get; set; }
        [JsonProperty(PropertyName = "isEurope")]
        public int IsEurope { get; set; }
        [JsonProperty(PropertyName = "allowPrivilege")]
        public int AllowPrivilege { get; set; }
        [JsonProperty(PropertyName = "disabledPrivilegeByDate")]
        public int DisabledPrivilegeByDate { get; set; }
    } // Correct

    public class From
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "station")]
        public string Station { get; set; }
        [JsonProperty(PropertyName = "stationTrain")]
        public string StationTrain { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
        [JsonProperty(PropertyName = "sortTime")]
        public int SortTime { get; set; }
        [JsonProperty(PropertyName = "srcDate")]
        public DateTime SrcDate { get; set; }
    } // Correct

    class To
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "station")]
        public string Station { get; set; }
        [JsonProperty(PropertyName = "stationTrain")]
        public string StationTrain { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
        [JsonProperty(PropertyName = "sortTime")]
        public int SortTime { get; set; }
    } // Correct

    class Types
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "letter")]
        public string Letter { get; set; }
        [JsonProperty(PropertyName = "places")]
        public int Places { get; set; }
    } // Correct

    class Child
    {
        [JsonProperty(PropertyName = "minDate")]
        public DateTime MinDate { get; set; }
        [JsonProperty(PropertyName = "maxDate")]
        public DateTime MaxDate { get; set; }
    } // Correct


}
