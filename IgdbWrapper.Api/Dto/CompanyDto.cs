using Newtonsoft.Json;

namespace IgdbWrapper.Api.Dto
{
    public class CompanyDto : BaseDto
    {
        [JsonProperty("name")]
        public string CompanyName { get; set; }

        [JsonProperty("logo")]
        public IgdbImageDto CompanyLogo { get; set; }

        [JsonProperty("description")]
        public string CompanyDescription { get; set; }

        [JsonProperty("website")]
        public string WebsiteUrl { get; set; }
    }
}