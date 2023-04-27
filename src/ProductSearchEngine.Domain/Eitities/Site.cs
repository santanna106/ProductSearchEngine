namespace ProductSearchEngine.Domain.Eitities
{
    public sealed class Site : Entity
    {
        public string Name { get; set; }
        public List<SearchProduct> SearchProducts { get; } = new();
        public List<Product> Products { get; } = new();

        public Site() { }
        public Site(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Site(int id)
        {
            Id = id;
        }
    }
}
