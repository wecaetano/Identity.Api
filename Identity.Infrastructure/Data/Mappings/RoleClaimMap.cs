using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class RoleClaimsMap : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaims");

            //builder.HasKey(bc => new { bc.RoleId, bc.ClaimId });

            //builder.HasOne(bc => bc.Role)
            //    .WithMany(b => b.RoleClaims)
            //    .HasForeignKey(bc => bc.RoleId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(bc => bc.Claim)
            //    .WithMany(b => b.RoleClaims)
            //    .HasForeignKey(bc => bc.Id)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
