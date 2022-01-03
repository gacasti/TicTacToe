using System;

// Game Class

namespace TicTacToe.Models
{
    public record Game
    {
        public Guid Id { get; init; } // Immutable property only set at initialization
        public string PlayerOne { get; init; }
        public string PlayerTwo { get; init; }
        public string Winner { get; set; }
        public DateTimeOffset StartDT { get; init; }
        public DateTimeOffset EndDT { get; set; }
    }
}