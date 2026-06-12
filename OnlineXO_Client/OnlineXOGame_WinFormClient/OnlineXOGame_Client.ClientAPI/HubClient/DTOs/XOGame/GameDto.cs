using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.HubClient.DTOs.XOGame {
    public record GameDto {
        public string Id { get; init; } = string.Empty;
        public string? PlayerX { get; init; }
        public string? PlayerO { get; init; }
        public string Status { get; init; } = string.Empty;
        public string CurrentTurn { get; init; } = string.Empty;
        public string? Winner { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? StartedAt { get; init; }
        public DateTime? EndedAt { get; init; }
        public string[][] Board { get; init; } = new string[0][];
    }
}
