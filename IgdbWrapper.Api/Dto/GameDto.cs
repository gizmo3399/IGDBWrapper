using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IgdbWrapper.Api.Dto
{
    public class GameDto : BaseDto
    {
        public GameDto()
        {
            Publishers = new List<CompanyDto>();
        }

        [JsonProperty("name")]
        public string GameName { get; set; }
        public string Slug { get; set; }
        [JsonProperty("url")]
        public string GameUrl { get; set; }
        [JsonProperty("summary")]
        public string GameSummary { get; set; }
        [JsonProperty("developers")]
        public long[] DeveloperIds { get; set; }
        [JsonProperty("category")]
        public long GameCategory { get; set; }
        [JsonProperty("platforms")]
        public long[] PlatformIds { get; set; }
        [JsonProperty("status")]
        public long GameStatus { get; set; }
        [JsonProperty("release_dates")]
        public ReleaseDateDto[] ReleaseDateIds { get; set; }
        [JsonProperty("first_release_date")]
        public DateTime FirstReleaseDate { get; set; }
        [JsonProperty("rating")]
        public double UserRating { get; set; }
        [JsonProperty("publishers")]
        public long[] PublisherIds { get; set; }
        [JsonProperty("cover")]
        public IgdbImageDto CoverImage { get; set; }
        [JsonProperty("time_to_beat")]
        public TimeToBeatDto TimeToBeat { get; set; }

        public virtual ICollection<CompanyDto> Publishers { get; set; }
    }
}