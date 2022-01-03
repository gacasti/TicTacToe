using System;

namespace TicTacToe.Dtos
{

    public record PlayerMoveDto
    {
        public Guid Id { get; init; }
        public Guid GameId { get; init; }
        public string Player { get; init; }
        public string PlayerMoveDescription { get; set; } // ie.: top left, middle right
        public string WinsGame { get; set; } // ie.: 'yes' or could default to 'no'
        public string PlayerMoveResponse { get; set; }
        public DateTimeOffset PlayerMoveDT { get; init; }
    }
}