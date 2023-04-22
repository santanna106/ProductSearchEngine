namespace ProductSearchEngine.Domain
{
    public sealed class SearchProduct : Entity
    {
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
