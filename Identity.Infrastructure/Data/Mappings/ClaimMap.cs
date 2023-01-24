using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class ClaimMap : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claims");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");
        }
    }
}
