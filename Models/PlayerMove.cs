using System;

// PlayerMove class
namespace TicTacToe.Models
{
    public record PlayerMove
    {
        public Guid Id { get; init; }
        public Guid GameId { get; init; }
        public string Player { get; init; }
        public string PlayerMoveDescription { get; init; }
        public string WinsGame { get; set; }
        public string PlayerMoveResponse { get; set; }
        public DateTimeOffset PlayerMoveDT { get; init; }
    }
}