using System;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

public interface IXOGameRepository : IBaseRepository<XOGame> { }
