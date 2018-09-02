using Newtonsoft.Json;

namespace IgdbWrapper.Api.Dto
{
    public class PlatformDto : BaseDto
    {
        [JsonProperty("name")]
        public string PlatformName { get; set; }

        [JsonProperty("logo")]
        public IgdbImageDto PlatformLogo { get; set; }

        [JsonProperty("website")]
        public string PlatformWebsite { get; set; }

        [JsonProperty("summary")]
        public string PlatformSummary { get; set; }
    }
}