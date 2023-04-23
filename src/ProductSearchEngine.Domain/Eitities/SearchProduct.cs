namespace ProductSearchEngine.Domain.Eitities
{
    public sealed class SearchProduct : Entity
    {
        public int SiteId { get; set; }
        public Site Site { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
