using CrawlerServiceRoot.Domain.Batches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerServiceDbPart.Db.Configurations;

public sealed class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder.HasKey(e => e.BatchId);
        builder.HasIndex(e => e.BatchName).IsUnique();

        builder.Property(e => e.BatchName).HasMaxLength(BatchConstants.BatchNameLength);
        builder.Property(e => e.IsOpen).HasDefaultValue(0);
        builder.Property(e => e.AutoCreateNextPart).HasDefaultValue(0);
    }
}
