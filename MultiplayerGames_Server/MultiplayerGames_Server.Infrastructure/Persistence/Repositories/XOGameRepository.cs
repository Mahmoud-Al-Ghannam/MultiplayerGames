using System;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Repositories;

internal class XOGameRepository : BaseRepository<XOGame>, IXOGameRepository
{
    public XOGameRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
