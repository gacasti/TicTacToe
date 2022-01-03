using TicTacToe.Dtos;
using TicTacToe.Models;

namespace TicTacToe
{
    public static class Extensions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto
            {
                Id = game.Id,
                PlayerOne = game.PlayerOne,
                PlayerTwo = game.PlayerTwo,
                Winner = game.Winner,
                StartDT = game.StartDT,
                EndDT = game.EndDT

            };
        }

        public static PlayerMoveDto AsDto(this PlayerMove playerMove)
        {
            return new PlayerMoveDto
            {
                Id = playerMove.Id,
                GameId = playerMove.GameId,
                Player = playerMove.Player,
                WinsGame = playerMove.WinsGame,
                PlayerMoveResponse = playerMove.PlayerMoveResponse,
                PlayerMoveDT = playerMove.PlayerMoveDT

            };
        }

    }

}