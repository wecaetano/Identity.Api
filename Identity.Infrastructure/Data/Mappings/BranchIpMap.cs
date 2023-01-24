using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class BranchIpMap : IEntityTypeConfiguration<BrancheIp>
    {
        public void Configure(EntityTypeBuilder<BrancheIp> builder)
        {
            builder.ToTable("BranchIps");

            builder.HasKey(bc => new { bc.BranchId, bc.Range });

            builder.Property(b => b.Range)
                .HasColumnName("Range")
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");
        }
    }
}
