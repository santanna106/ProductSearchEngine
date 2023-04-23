namespace ProductSearchEngine.Domain.Eitities
{
    public sealed class Category : Entity
    {
        public string Name { get; set; }

        public List<Product> Products { get; } = new();

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
