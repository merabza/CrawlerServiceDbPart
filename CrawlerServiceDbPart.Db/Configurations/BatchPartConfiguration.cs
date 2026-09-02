using CrawlerServiceRoot.Domain.BatchParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerServiceDbPart.Db.Configurations;

public sealed class BatchPartConfiguration : IEntityTypeConfiguration<BatchPart>
{
    public void Configure(EntityTypeBuilder<BatchPart> builder)
    {
        builder.HasKey(e => e.BpId);
        builder.HasIndex(e => new { e.BatchId, e.Created }).IsUnique();

        builder.HasOne(d => d.BatchNavigation).WithMany(p => p.BatchParts).HasForeignKey(d => d.BatchId);
    }
}
