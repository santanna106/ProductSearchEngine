using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Infrastructure.Repository;
using ProductSearchEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchEngine.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
           //Repositories
           services.AddScoped<IProductRepository, ProductRepository>();
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<ISiteRepository, SiteRepository>();
      
            services.AddScoped<IProductSearch, ProductSearchBuscape>();
            services.AddScoped<IFactoryProductSearch, FactoryProductSearch>();
            services.AddScoped<IDefineLinkSearch, DefineLinkSearch>();

            return services;
        }
    }
}
