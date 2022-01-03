using System;
using TicTacToe.Models;
using TicTacToe.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Dtos;
using System.Threading.Tasks;

namespace TicTacToe.Controllers
{
    // GET /games

    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository repository; // explicit dependency not ideal, implemented just for simplicity

        public GamesController(IGamesRepository repository) // dependency injection
        {
            this.repository = repository;
        }

        // GET /games thru Data Transfer Object (DTO)
        [HttpGet]
        public async Task<IEnumerable<GameDto>> GetGamesAsync()
        {
            // In order to comply with the syntax the compiler is expecting with Asyncrhonous call
            var games = (await repository.GetGamesAsync()) // finish getting number of games
                        .Select(game => game.AsDto()); // and then turn to DTO objects

            return games;
        }

        // GET /games/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGameAsync(Guid id)
        {
            var game = await repository.GetGameAsync(id);

            if (game is null)
            {
                return NotFound();
            }
            return game.AsDto();
        }

        // POST /games
        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateGameAsync(CreateGameDto gameDto)
        {

            Game game = new()
            {
                Id = Guid.NewGuid(),
                PlayerOne = gameDto.PlayerOne,
                PlayerTwo = gameDto.PlayerTwo,
                StartDT = DateTimeOffset.UtcNow
            };

            await repository.CreateGameAsync(game);

            return CreatedAtAction(nameof(GetGameAsync), new { id = game.Id }, game.AsDto());
        }

        // PUT /games/{id}
        [HttpPut("{id}")] // {id} provides template of item to be updated

        public async Task<ActionResult> UpdateGameAsync(Guid id, UpdateGameDto gameDto)
        {
            var savedGame = await repository.GetGameAsync(id);

            if (savedGame is null)
            {
                return NotFound();
            }

            Game updatedGame = savedGame with
            { // Record Type using With-expressions
                PlayerOne = gameDto.PlayerOne,
                PlayerTwo = gameDto.PlayerTwo
            };

            await repository.UpdateGameAsync(updatedGame);

            return NoContent();
        }

        // DELETE /games/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameAsync(Guid id)
        {

            var savedGame = await repository.GetGameAsync(id);

            if (savedGame is null)
            {
                return NotFound();
            }

            await repository.DeleteGameAsync(id);

            return NoContent();

        }
    }
}