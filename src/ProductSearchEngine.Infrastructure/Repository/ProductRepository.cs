using Microsoft.EntityFrameworkCore;
using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Infrastructure.Context;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductSearchEngine.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext contexto) : base(contexto) { }

        public async Task addListProducts(IEnumerable<Product> products, int siteId)
        {

            Site site = new(siteId);
            foreach (Product product in products)
            {
               
               await Add(product);

                _context.Products.Attach(product);
                _context.Sites.Attach(site);
                product.Sites.Add(site);

                _context.SaveChanges();
            }
               
        }

        public async Task<IEnumerable<Product>>
            GetProductCategorySite(int siteId,
            int categoryId,
            string description)
        {
            
            List<Product> products;
            if (string.IsNullOrEmpty(description))
            {
                
               var query = from p in _context.Products
                           join searchP in _context.SearchProducts on p.Id equals searchP.ProductId
                           join category in _context.Categories on p.CategoryId equals category.Id
                        where p.CategoryId == categoryId
                           && searchP.SiteId == siteId

                           select new Product
                        {
                            Name = p.Name,
                            Img = p.Img,
                            Description = p.Description,
                            Price = p.Price,
                            Sites = (from sp in _context.SearchProducts
                                     join s in _context.Sites on sp.SiteId equals s.Id
                                     where sp.ProductId == p.Id
                                     select s).ToList(),
                            Category = category,
                            CategoryId = categoryId
                        };
                products = query.ToList();

            } else {
                var query = from p in _context.Products
                        join category in _context.Categories on p.CategoryId equals category.Id
                        where p.CategoryId == categoryId
                           && p.Description.Contains(description)
                        select new Product
                        {
                            Name = p.Name,
                            Img = p.Img,
                            Description = p.Description,
                            Price = p.Price,
                            Sites = (from sp in _context.SearchProducts
                                     join s in _context.Sites on sp.SiteId equals s.Id
                                     where sp.ProductId == p.Id
                                     select s).ToList(),
                            Category = category,
                            CategoryId = categoryId
                        };
                products = query.ToList();
            }


            return products;
        }
    }
}
