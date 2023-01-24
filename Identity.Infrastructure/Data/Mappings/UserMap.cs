using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            //builder.Property(b => b.Id)
            //    .HasColumnName("Id");

            //builder.HasOne<IdentityUser>().WithOne().HasForeignKey<User>(x => x.Id);

            //builder.Property(b => b.UserName)
            //    .HasColumnName("UserName")
            //    .HasMaxLength(50)
            //    .HasColumnType("varchar(50)");

            //builder.Property(b => b.PasswordHash)
            //    .HasColumnName("PasswordHash")
            //    .HasMaxLength(1200)
            //    .HasColumnType("varchar(1200)");
        }
    }
}
