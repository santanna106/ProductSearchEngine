using ProductSearchEngine.Domain.Enum;
using ProductSearchEngine.Domain.Interfaces;

namespace ProductSearchEngine.Services
{
    public class FactoryProductSearch : IFactoryProductSearch
    {
        private readonly IProductSearchBuscape _productSearchBuscape;
        private readonly IProductSearchMercadoLivre _productSearchMercadoLivre;

        public FactoryProductSearch(IProductSearchBuscape productSearchBuscape,
            IProductSearchMercadoLivre productSearchMercadoLivre)
        {
            _productSearchBuscape = productSearchBuscape;
            _productSearchMercadoLivre = productSearchMercadoLivre;
        }
        public IProductSearch CreateProductSearch(int typeSearch)
        {
            IProductSearch typeSearchObject;
            switch (typeSearch) {
                case (int) TypeProductSearch.ProductSerachBuscaPe:
                    typeSearchObject = _productSearchBuscape;
                    break;
                case (int)TypeProductSearch.ProductSerachMercadoLivre:
                    typeSearchObject = _productSearchMercadoLivre;
                    break;
                default:
                    typeSearchObject = _productSearchBuscape;
                    break;
            }

            return typeSearchObject;
        }
    }
}
