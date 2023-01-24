using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("UserClaims");

            //builder.HasKey(bc => new { bc.UserId, bc.ClaimId });

            //builder.HasOne(bc => bc.User)
            //    .WithMany(b => b.UserClaims)
            //    .HasForeignKey(bc => bc.UserId);

            //builder.HasOne(bc => bc.Claim)
            //    .WithMany(b => b.UserClaims)
            //    .HasForeignKey(bc => bc.ClaimId);

            //builder.Property(b => b.Value)
            //    .HasColumnName("Value")
            //    .HasColumnType("bit");
        }
    }
}
