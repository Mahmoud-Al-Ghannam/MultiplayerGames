using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiplayerGames_Server.Domain.Aggregates.Test;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.Property<byte[]>("RowVersion").IsConcurrencyToken();
    }
}
