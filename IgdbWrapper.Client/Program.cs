using IgdbWrapper.Api;
using IgdbWrapper.Api.Dto;
using IgdbWrapper.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IgdbWrapper.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = new IgdbClient();
            api.Initialize("ad6c3241cdb3b1c029e4381380e419d4");

            Console.WriteLine("Enter a game name to request data.");
            var game = Console.ReadLine();
            if (string.IsNullOrEmpty(game))
                return;

            Console.WriteLine($"Requesting data for game: {game}");
            try
            {
                var foundGames = api.GetGamesByNameAsync(game).Result.ToList();
                if (!foundGames.Any())
                {
                    Console.WriteLine("Could not find info for the game");
                    return;
                }

                DisplayGameInfo(foundGames.ToList(), api);
            }
            catch (ApiException e)
            {
                Console.WriteLine($"An error occurred while requesting data {e}");

            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void DisplayGameInfo(List<GameDto> games, IgdbClient client)
        {
            Console.WriteLine($"Found {games.Count} game(s)");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"Game name: {game.GameName}");
                Console.WriteLine($"Game summary: {game.GameSummary}");
                Console.WriteLine($"Game status: {game.GameStatus}");
                //Console.WriteLine($"Game cover URL: {client.GetFullImageUrl(game.CoverImage, ImageType.CoverBig)}");
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}