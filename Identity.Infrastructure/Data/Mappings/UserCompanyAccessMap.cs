using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class UserCompanyAccessMap : IEntityTypeConfiguration<UserCompanyAccess>
    {
        public void Configure(EntityTypeBuilder<UserCompanyAccess> builder)
        {
            builder.ToTable("UserCompanyAccess");

            builder.HasKey(bc => new { bc.UserId, bc.BranchId });

            builder.HasOne(b => b.User)
                .WithMany(b => b.UserCompanyAccesses)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Branch)
                .WithMany(b => b.UserCompanyAccesses)
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
