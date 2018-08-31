using Newtonsoft.Json;

namespace IgdbWrapper.Api.Dto
{
    public class IgdbImageDto
    {
        [JsonProperty("url")]
        public string ImageUrl { get; set; }

        [JsonProperty("width")]
        public int ImageWidth { get; set; }

        [JsonProperty("height")]
        public int ImageHeight { get; set; }
    }
}