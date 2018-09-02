using IgdbWrapper.Api.Enums;
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
            Developers = new List<CompanyDto>();
            Platforms = new List<PlatformDto>();
        }

        [JsonProperty("name")]
        public string GameName { get; set; }
        [JsonProperty("url")]
        public string GameUrl { get; set; }
        [JsonProperty("summary")]
        public string GameSummary { get; set; }
        [JsonProperty("developers")]
        public long[] DeveloperIds { get; set; }
        [JsonProperty("category")]
        public GameCategory GameCategory { get; set; }
        [JsonProperty("platforms")]
        public long[] PlatformIds { get; set; }
        [JsonProperty("status")]
        public GameStatus GameStatus { get; set; }
        [JsonProperty("release_dates")]
        public ReleaseDateDto[] ReleaseDates { get; set; }
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

        public ICollection<CompanyDto> Publishers { get; set; }
        public ICollection<CompanyDto> Developers { get; set; }
        public ICollection<PlatformDto> Platforms { get; set; }
    }
}