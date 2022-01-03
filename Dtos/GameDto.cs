using System;
// Create a Data Transfer Object class for Game
namespace TicTacToe.Dtos
{

    public record GameDto
    {
        public Guid Id { get; init; } // Immutable property only set at initialization
        public string PlayerOne { get; init; }
        public string PlayerTwo { get; init; }
        public string Winner { get; init; }
        public DateTimeOffset StartDT { get; init; }
        public DateTimeOffset EndDT { get; init; }
    }
}