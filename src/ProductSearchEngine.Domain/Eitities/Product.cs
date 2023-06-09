﻿namespace ProductSearchEngine.Domain.Eitities
{
    public sealed class Product : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public string? Img { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<SearchProduct> SearchProducts { get; } = new();
        public List<Site> Sites { get; set; } = new();
        public Product() { }
        public Product(List<Site> sites)
        {
            Sites = sites;
        }
    }
}
