using IgdbWrapper.Api.Helpers;
using Newtonsoft.Json;
using System;

namespace IgdbWrapper.Api.Dto
{
    public class TimeToBeatDto
    {
        [JsonProperty("hastly")]
        [JsonConverter(typeof(SecondsIntoTimespanConverter))]
        public TimeSpan FastCompletion { get; set; }

        [JsonProperty("normally")]
        [JsonConverter(typeof(SecondsIntoTimespanConverter))]
        public TimeSpan NormalCompletion { get; set; }

        [JsonProperty("completely")]
        [JsonConverter(typeof(SecondsIntoTimespanConverter))]
        public TimeSpan TotalCompletion { get; set; }
    }
}