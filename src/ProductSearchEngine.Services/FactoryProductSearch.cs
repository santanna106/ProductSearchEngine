using ProductSearchEngine.Domain.Enum;
using ProductSearchEngine.Domain.Interfaces;

namespace ProductSearchEngine.Services
{
    public class FactoryProductSearch : IFactoryProductSearch
    {
        public IProductSearch CreateProductSearch(int typeSearch)
        {
            IProductSearch typeSearchObject;
            switch (typeSearch) {
                case (int) TypeProductSearch.ProductSerachBuscaPe:
                    typeSearchObject = new ProductSearchBuscape();
                    break;
                case (int)TypeProductSearch.ProductSerachMercadoLivre:
                    typeSearchObject = new ProductSearchMercadoLivre();
                    break;
                default:
                    typeSearchObject = new ProductSearchBuscape();
                    break;
            }

            return typeSearchObject;
        }
    }
}
