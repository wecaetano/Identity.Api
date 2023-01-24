using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class DataSourceMap : IEntityTypeConfiguration<DataSource>
    {
        public void Configure(EntityTypeBuilder<DataSource> builder)
        {
            builder.ToTable("DataSource");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");
        }
    }
}
