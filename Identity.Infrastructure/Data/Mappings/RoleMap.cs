using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            //builder.HasKey(b => b.Id);

            //builder.Property(b => b.Name)
            //    .HasColumnName("Name")
            //    .HasMaxLength(50)
            //    .HasColumnType("varchar(50)");
        }
    }
}
