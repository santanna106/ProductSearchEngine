using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Infrastructure.EntitiesMappings
{
    public class SiteMapping : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("tSite");

            builder.HasKey(m => m.Id);

            builder.Property(prop => prop.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .HasColumnType("integer")
                   .ValueGeneratedNever(); 

            builder.Property(m => m.Name)
                    .IsRequired(true)
                    .HasColumnName("name")
                    .HasMaxLength(200);
        }
    }
}
