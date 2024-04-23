using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.core.EfCore.TablesConfiguration;

public class ConfigureTable<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    protected EntityTypeBuilder<T> Builder;

    public void Configure(EntityTypeBuilder<T> builder)
    {
        Builder = builder;
        ConfigureDefaults();
        ConfigureCustomizations();
    }

    private void ConfigureDefaults()
    {
        var tableName = typeof(T).Name;
        Builder.ToTable(tableName);
        Builder.Property(p => p.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        Builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
        Builder.HasIndex(t => t.Id);
        //SoftDelete will be excluded from the query results.
        Builder.HasQueryFilter(b => !b.IsDeleted);
    }

    protected virtual void ConfigureCustomizations()
    {
        // Override this method in a derived class to add additional configuration
    }
}