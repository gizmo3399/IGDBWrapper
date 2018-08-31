using IgdbWrapper.Api;
using IgdbWrapper.Api.Dto;
using IgdbWrapper.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IgdbWrapper.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new IgdbClient();
            api.Initialize("471ee7d1b7b9c9aec7652fb1f2563cd5");

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

                DisplayGameInfo(foundGames.ToList());
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

        private static void DisplayGameInfo(List<GameDto> games)
        {
            Console.WriteLine($"Found {games.Count} game(s)");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"Game name: {game.GameName}");
                Console.WriteLine($"Game summary: {game.GameSummary}");
                Console.WriteLine($"Game slug: {game.Slug}");
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}