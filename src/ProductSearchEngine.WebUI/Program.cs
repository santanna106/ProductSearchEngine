using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Infrastructure.Context;
using ProductSearchEngine.Infrastructure.Repository;
using ProductSearchEngine.Services;
using HtmlAgilityPack;

var builder = WebApplication.CreateBuilder(args);
//var startup = new Startup(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
        ));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();

builder.Services.AddScoped<HttpClient, HttpClient>();
builder.Services.AddScoped<HtmlDocument, HtmlDocument>();

builder.Services.AddScoped<IProductSearchBuscape, ProductSearchBuscape>();
builder.Services.AddScoped<IProductSearchMercadoLivre, ProductSearchMercadoLivre>();
builder.Services.AddScoped<IFactoryProductSearch, FactoryProductSearch>();
builder.Services.AddScoped<IDefineLinkSearch, DefineLinkSearch>();

var app = builder.Build();

//startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProductSearch}/{action=Index}/{id?}");



app.Run();
