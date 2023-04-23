namespace ProductSearchEngine.Domain.Eitities
{
    public sealed class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<SearchProduct> SearchProducts { get; } = new();
        public List<Site> Sites { get; } = new();
    }
}
