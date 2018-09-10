using IgdbWrapper.Api.Dto;
using IgdbWrapper.Api.Enums;
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

        /// <summary>
        /// Gets a full URL for an image from IGDB.
        /// </summary>
        /// <param name="image">The image to get the full URL for.</param>
        /// <returns>The fully qualified URL to the image that is specified.</returns>
        string GetFullImageUrl(IgdbImageDto image);

        /// <summary>
        /// Gets a full URL for an image from IGDB in a specific size.
        /// </summary>
        /// <param name="image">The image to get the full URL for.</param>
        /// <param name="imageType">As what type of image the retrieve the URL for.</param>
        /// <param name="retinaImage">Set to <c>true</c> to get a retina (DPR 2.0) version of the image</param>
        /// <returns>The fully qualified URL to the image that is specified.</returns>
        string GetFullImageUrl(IgdbImageDto image, ImageType imageType, bool retinaImage = false);
    }
}