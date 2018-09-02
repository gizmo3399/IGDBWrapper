using IgdbWrapper.Api.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgdbWrapper.Api.Abstractions
{
    /// <summary>
    /// Interface that defines the client that can interact with the IGDB API.
    /// </summary>
    public interface IIgdbClient
    {
        void Initialize(string apiKey);

        /// <summary>
        /// Gets the first game with a name matching <see cref="gameName"/> from the IGDB API.
        /// </summary>
        /// <param name="gameName">The name of the game to search for.</param>
        /// <returns>The first game that was found that matches the given <see cref="gameName"/>.</returns>
        Task<GameDto> GetGameByNameAsync(string gameName);

        /// <summary>
        /// Gets all of the games with a name matching <see cref="gameName"/> from the IGDB API.
        /// </summary>
        /// <param name="gameName">The name of the game to search for.</param>
        /// <returns>All of the games that were found matching the given <see cref="gameName"/>.</returns>
        Task<IEnumerable<GameDto>> GetGamesByNameAsync(string gameName);

        /// <summary>
        /// Gets a Company from the IGDB API by using it's ID.
        /// </summary>
        /// <param name="id">The ID of the company to find.</param>
        /// <returns>The company that has the given <see cref="id"/>.</returns>
        Task<CompanyDto> GetCompanyById(long id);

        /// <summary>
        /// Gets a gaming platform from the IGDB API by using it's ID.
        /// </summary>
        /// <param name="id">The ID of the gaming platform to find.</param>
        /// <returns>The gaming platform that has the given <see cref="id"/>.</returns>
        Task<PlatformDto> GetPlatformById(long id);
    }
}