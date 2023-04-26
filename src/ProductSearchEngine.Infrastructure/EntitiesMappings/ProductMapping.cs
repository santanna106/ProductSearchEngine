using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Infrastructure.EntitiesMappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tProduct");

            builder.HasKey(m => m.Id);

            builder.Property(prop => prop.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .HasColumnType("integer");

            builder.Property(m => m.Name)
                    .IsRequired(true)
                    .HasColumnName("name")
                    .HasMaxLength(100);

            builder.Property(m => m.Description)
                  .IsRequired(false)
                  .HasColumnName("description")
                  .HasMaxLength(200);

            builder.Property(m => m.Price)
            .IsRequired(false)
            .HasColumnName("price")
            .HasMaxLength(50);

            builder.Property(m => m.Img)
               .IsRequired(false)
               .HasColumnName("img")
               .HasMaxLength(300);

            builder.HasOne(prop => prop.Category)
             .WithMany(cs => cs.Products)
             .HasForeignKey(c => c.CategoryId);

            builder.HasMany(e => e.Sites)
                   .WithMany(e => e.Products)
                   .UsingEntity<SearchProduct>();
        }
    }
}
