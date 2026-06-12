using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame {
    public record GameItemDto {
        public string Id { get; init; } = string.Empty;
        public string? PlayerXId { get; init; }
        public string? PlayerX { get; init; }
        public string? PlayerOId { get; init; }
        public string? PlayerO { get; init; }
        public string Status { get; init; } = string.Empty;
        public string CurrentTurn { get; init; } = string.Empty;
        public string? Winner { get; init; }
    }
}
