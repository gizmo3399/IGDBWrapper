using IgdbWrapper.Api.Enums;
using Newtonsoft.Json;

namespace IgdbWrapper.Api.Dto
{
    public class ReleaseDateDto : BaseDto
    {
        [JsonProperty("human")]
        public string ReleaseDateString { get; set; }

        [JsonProperty("region")]
        public Region ReleaseRegion { get; set; }

        [JsonProperty("m")]
        public int Month { get; set; }

        [JsonProperty("y")]
        public int Year { get; set; }

        [JsonProperty("date")]
        public long ReleaseDate { get; set; }
    }
}