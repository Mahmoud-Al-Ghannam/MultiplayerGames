using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Domain.Aggregates.User;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(
        Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder
    )
    {
        builder.HasKey(u => u.Id);
    }
}
