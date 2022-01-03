using System;
using System.Collections.Generic;
using TicTacToe.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        // Sample initial dataset
        private readonly List<Game> games = new()
        {
            new Game { Id = Guid.NewGuid(), PlayerOne = "Player One", PlayerTwo = "Player Two", StartDT = DateTimeOffset.UtcNow },
            new Game { Id = Guid.NewGuid(), PlayerOne = "Player Three", PlayerTwo = "Player Four", StartDT = DateTimeOffset.UtcNow },
            new Game { Id = Guid.NewGuid(), PlayerOne = "Player Five", PlayerTwo = "Player Six", StartDT = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await Task.FromResult(games);
        }

        public async Task<Game> GetGameAsync(Guid id)
        {
            var item = games.Where(Game => Game.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateGameAsync(Game game)
        {
            games.Add(game);
            await Task.CompletedTask;
        }

        public async Task UpdateGameAsync(Game game)
        {
            var index = games.FindIndex(savedGame => savedGame.Id == game.Id);
            games[index] = game;
            await Task.CompletedTask;
        }

        public async Task DeleteGameAsync(Guid id)
        {
            var index = games.FindIndex(savedGame => savedGame.Id == id);
            games.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}