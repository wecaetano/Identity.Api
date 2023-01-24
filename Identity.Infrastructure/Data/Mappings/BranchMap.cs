using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class BranchMap : IEntityTypeConfiguration<Branche>
    {
        public void Configure(EntityTypeBuilder<Branche> builder)
        {
            builder.ToTable("Branches");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(b => b.ShortName)
                .HasColumnName("ShortName")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(b => b.Code)
                .HasColumnName("Code")
                .HasMaxLength(3)
                .HasColumnType("varchar(3)");
        }
    }
}
