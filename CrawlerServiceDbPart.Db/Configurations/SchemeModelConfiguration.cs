using CrawlerServiceRoot.Domain.SchemeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerServiceDbPart.Db.Configurations;

public sealed class SchemeModelConfiguration : IEntityTypeConfiguration<SchemeModel>
{
    public void Configure(EntityTypeBuilder<SchemeModel> builder)
    {
        const string tableName = "Schemes";
        builder.ToTable(tableName);

        builder.HasKey(e => e.SchId);
        builder.HasIndex(e => e.SchName).IsUnique();

        builder.Property(e => e.SchName).HasMaxLength(SchemeModelsConstants.SchemeNameLength);
        builder.Property(e => e.SchProhibited).HasDefaultValue(0);
    }
}
