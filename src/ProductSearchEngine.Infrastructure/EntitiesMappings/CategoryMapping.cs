using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Infrastructure.EntitiesMappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("tCategory");

            builder.HasKey(m => m.Id);

            builder.Property(prop => prop.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .HasColumnType("integer")
                   .ValueGeneratedNever();

            builder.Property(m => m.Name)
                    .IsRequired(true)
                    .HasColumnName("name")
                    .HasMaxLength(60);
        }
    }
}
