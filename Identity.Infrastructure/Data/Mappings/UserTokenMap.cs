using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserTokens");

            //builder.HasKey(b => b.Id);

            //builder.Property(b => b.Value)
            //   .HasColumnName("Value")
            //   .HasMaxLength(1200)
            //   .HasColumnType("varchar(1200)");

            //builder.Property(b => b.LifeCycle)
            //   .HasColumnName("LifeCycle")
            //   .HasColumnType("datetime");
        }
    }
}
