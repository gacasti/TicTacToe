using System;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Dtos
{

    public record CreateGameDto
    {
        [Required]
        public string PlayerOne { get; init; }
        [Required]
        public string PlayerTwo { get; init; }
        public DateTimeOffset StartDT { get; init; }

    }
}