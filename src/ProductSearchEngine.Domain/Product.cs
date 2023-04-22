namespace ProductSearchEngine.Domain
{
    public sealed class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Site Site { get; set; }
        public int SiteId { get; set; }
    }
}
