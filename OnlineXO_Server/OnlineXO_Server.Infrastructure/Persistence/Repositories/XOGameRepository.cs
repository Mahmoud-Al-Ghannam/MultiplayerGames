using System;
using OnlineXO_Server.Application.Abstractions.Data.Repositories;
using OnlineXO_Server.Domain.Aggregates.XOGame;
using OnlineXO_Server.Infrastructure.Persistence.Data;

namespace OnlineXO_Server.Infrastructure.Persistence.Repositories;

internal class XOGameRepository : BaseRepository<XOGame>, IXOGameRepository
{
    public XOGameRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
