using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.WebUI.DTO
{
    public class ProductDTO
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Site> Sites { get; set; }
    }
}
