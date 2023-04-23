using Microsoft.EntityFrameworkCore;
using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Infrastructure.Context
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Category>()
            .HasData(
                    new Category(1, "Mobile"),
                    new Category(2, "Refrigerator"),
                    new Category(3, "Tv")
             );

            modelBuilder.Entity<Site>()
            .HasData(
                    new Site(1, "Mercado Livre"),
                    new Site(2, "Buscapé")
             );
        }
    }
}
