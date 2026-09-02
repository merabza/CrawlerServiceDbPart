using CrawlerServiceRoot.Domain.HostsByBatches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerServiceDbPart.Db.Configurations;

public sealed class HostByBatchConfiguration : IEntityTypeConfiguration<HostByBatch>
{
    public void Configure(EntityTypeBuilder<HostByBatch> builder)
    {
        const string tableName = "HostsByBatches";
        builder.ToTable(tableName);

        builder.HasKey(e => e.HbbId);
        builder.HasIndex(e => new { e.BatchId, e.SchemeId, e.HostId }).IsUnique();

        builder.HasOne(d => d.BatchNavigation).WithMany(p => p.HostsByBatches).HasForeignKey(d => d.BatchId);
        builder.HasOne(d => d.SchemeNavigation).WithMany(p => p.HostsByBatches).HasForeignKey(d => d.SchemeId);
        builder.HasOne(d => d.HostNavigation).WithMany(p => p.HostsByBatches).HasForeignKey(d => d.HostId);
    }
}
