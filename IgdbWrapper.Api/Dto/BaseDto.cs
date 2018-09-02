using Newtonsoft.Json;
using System;

namespace IgdbWrapper.Api.Dto
{
    public class BaseDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string ResourceUrl { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}