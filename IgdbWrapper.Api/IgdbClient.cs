using IgdbWrapper.Api.Abstractions;
using IgdbWrapper.Api.Dto;
using IgdbWrapper.Api.Exceptions;
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
        }

        //TODO Allow LINQ style building of queries and filters.

        public async Task<GameDto> GetGameByNameAsync(string gameName)
        {
            var foundGames = await GetGamesByNameAsync(gameName);
            return foundGames?.FirstOrDefault();
        }

        public async Task<IEnumerable<GameDto>> GetGamesByNameAsync(string gameName)
        {
            var requestUrl = $"{Endpoints.GameEndpoint}/?fields=*&search={gameName}";
            var result = await _httpClient.GetAsync(requestUrl);
            if (!result.IsSuccessStatusCode)
                throw new ApiException($"Could not fetch games because the request returned: {result.StatusCode} with reason: {result.ReasonPhrase}");

            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<GameDto>>(json);
        }
    }
}