using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            //builder.HasKey(bc => new { bc.RoleId, bc.ApplicationId });

            //builder.Property(x => x.UserId).HasColumnName("UserId");

            //builder.HasOne(b => b.User)
            //   .WithMany(b => b.UserRoles)
            //   .HasForeignKey(b => b.UserId)
            //   .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(b => b.Role)
            //    .WithMany(b => b.UserRoles)
            //    .HasForeignKey(b => b.RoleId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Property(b => b.IsDefault)
            //   .HasColumnName("IsDefault")
            //   .HasColumnType("bit");
        }
    }
}
