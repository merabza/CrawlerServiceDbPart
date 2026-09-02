using CrawlerServiceRoot.Domain.ExtensionModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerServiceDbPart.Db.Configurations;

public sealed class ExtensionModelConfiguration : IEntityTypeConfiguration<ExtensionModel>
{
    public void Configure(EntityTypeBuilder<ExtensionModel> builder)
    {
        const string tableName = "Extensions";
        builder.ToTable(tableName);

        builder.HasKey(e => e.ExtId);
        builder.HasIndex(e => e.ExtName).IsUnique();

        builder.Property(e => e.ExtName).HasMaxLength(ExtensionModelsConstants.ExtensionNameLength);
        builder.Property(e => e.ExtProhibited).HasDefaultValue(0);
    }
}
