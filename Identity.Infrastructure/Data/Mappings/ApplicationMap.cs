using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class ApplicationMap : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Applications");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");
        }
    }
}
