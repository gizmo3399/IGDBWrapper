using IgdbWrapper.Api.Abstractions;
using IgdbWrapper.Api.Dto;
using IgdbWrapper.Api.Exceptions;
using IgdbWrapper.Api.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IgdbWrapper.Api
{
    public class IgdbClient : IIgdbClient
    {
        private bool _isInitialized;
        private HttpClient _httpClient;
        private JsonSerializerSettings _jsonSerializerSettings;

        public void Initialize(string apiKey)
        {
            if (_isInitialized)
                return; //Already initialized

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api-endpoint.igdb.com/")
            };

            //Add default headers.
            _httpClient.DefaultRequestHeaders.Add("user-key", apiKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _isInitialized = true;

            //Set-up JSON.NET serializer.
            _jsonSerializerSettings = new JsonSerializerSettings();
            _jsonSerializerSettings.Converters.Add(new MillisecondEpochConverter()); //Convert IGDB's Unix timestamps to DateTime objects.
            _jsonSerializerSettings.Formatting = Formatting.Indented;
        }

        //TODO Allow LINQ style building of queries and filters.

        public async Task<GameDto> GetGameByNameAsync(string gameName)
        {
            var foundGames = await GetGamesByNameAsync(gameName);
            return foundGames?.FirstOrDefault();
        }

        public async Task<IEnumerable<GameDto>> GetGamesByNameAsync(string gameName)
        {
            var requestUrl = $"{Endpoints.GameEndpoint}?fields=*&search={gameName}";
            var result = await _httpClient.GetAsync(requestUrl);
            if (!result.IsSuccessStatusCode)
                throw new ApiException($"Could not fetch games because the request returned: {result.StatusCode} with reason: {result.ReasonPhrase}");

            var json = await result.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<IEnumerable<GameDto>>(json, _jsonSerializerSettings);
            await GetExtraGameInformation(games);
            return games;
        }

        public async Task<CompanyDto> GetCompanyById(long id)
        {
            var requestUrl = $"{Endpoints.CompanyEndpoint}{id}?fields=*";
            var result = await _httpClient.GetAsync(requestUrl);
            if (!result.IsSuccessStatusCode)
                throw new ApiException($"Could not fetch company because the request returned: {result.StatusCode} with reason: {result.ReasonPhrase}");

            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CompanyDto>>(json, _jsonSerializerSettings).FirstOrDefault();
        }

        public async Task<PlatformDto> GetPlatformById(long id)
        {
            var requestUrl = $"{Endpoints.PlatformEndpoint}{id}?fields=*";
            var result = await _httpClient.GetAsync(requestUrl);
            if (!result.IsSuccessStatusCode)
                throw new ApiException($"Could not fetch platform because the request returned: {result.StatusCode} with reason: {result.ReasonPhrase}");

            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PlatformDto>>(json, _jsonSerializerSettings).FirstOrDefault();
        }

        private async Task GetExtraGameInformation(IEnumerable<GameDto> games)
        {
            foreach (var game in games)
            {
                //TODO find a more elegant way of loading related data.
                if (game.PublisherIds != null && game.PublisherIds.Any())
                {
                    //Get publisher info
                    foreach (var publisherId in game.PublisherIds)
                    {
                        var publisherInfo = await GetCompanyById(publisherId);
                        game.Publishers.Add(publisherInfo);
                    }
                }
                if (game.DeveloperIds != null && game.DeveloperIds.Any())
                {
                    //Get developer info.
                    foreach (var developerId in game.DeveloperIds)
                    {
                        var developerInfo = await GetCompanyById(developerId);
                        game.Developers.Add(developerInfo);
                    }
                }

                if (game.PlatformIds != null && game.PlatformIds.Any())
                {
                    //Get platform info.
                    foreach (var platformId in game.PlatformIds)
                    {
                        var platformInfo = await GetPlatformById(platformId);
                        game.Platforms.Add(platformInfo);
                    }
                }
            }
        }
    }
}