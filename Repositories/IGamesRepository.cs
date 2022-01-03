using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Repositories
{

    public interface IGamesRepository
    {
        Task<Game> GetGameAsync(Guid id);
        Task<IEnumerable<Game>> GetGamesAsync();
        Task CreateGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(Guid id);
    }
}