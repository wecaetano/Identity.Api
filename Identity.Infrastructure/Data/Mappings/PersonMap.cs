using Identity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasColumnName("Name")
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(b => b.DocumentId)
                .HasColumnName("DocumentId")
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");
        }
    }
}
