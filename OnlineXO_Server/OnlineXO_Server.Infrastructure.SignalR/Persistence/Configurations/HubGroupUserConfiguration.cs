using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineXO_Server.Domain.Aggregates.User;
using OnlineXO_Server.Infrastructure.SignalR.DataModels;

namespace OnlineXO_Server.Infrastructure.SignalR.Persistence.Configurations;

public class HubGroupUserConfiguration : IEntityTypeConfiguration<HubGroupUser>
{
    public void Configure(EntityTypeBuilder<HubGroupUser> builder)
    {
        builder.HasKey(g => g.Id);
    }
}
