namespace ProductSearchEngine.Domain.Interfaces
{
    public interface IFactoryProductSearch
    {
        IProductSearch CreateProductSearch(int typeSearch);
    }
}
