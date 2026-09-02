using CrawlerServiceRoot.Domain.HostModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerServiceDbPart.Db.Configurations;

public sealed class HostModelConfiguration : IEntityTypeConfiguration<HostModel>
{
    public void Configure(EntityTypeBuilder<HostModel> builder)
    {
        const string tableName = "Hosts";
        builder.ToTable(tableName);

        builder.HasKey(e => e.HostId);
        builder.HasIndex(e => e.HostName).IsUnique();

        builder.Property(e => e.HostName).HasMaxLength(HostModelConstants.HostNameLength);
        builder.Property(e => e.HostProhibited).HasDefaultValue(0);
    }
}
