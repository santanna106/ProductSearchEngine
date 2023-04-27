using ProductSearchEngine.Domain.Enum;
using ProductSearchEngine.Domain.Interfaces;

namespace ProductSearchEngine.Services
{
    public class DefineLinkSearch : IDefineLinkSearch
    {
        public string GetLink(int typeSearch, int category)
        {
            string link = string.Empty;
            if (typeSearch == (int) TypeProductSearch.ProductSerachBuscaPe)
            {
                switch (category)
                {
                    case (int)TypeCategory.Mobile:
                        link = "https://www.buscape.com.br/mobile";
                        break;
                    case (int)TypeCategory.Refrigerator:
                        link = "https://www.buscape.com.br/geladeira";
                        break;
                    case (int)TypeCategory.TV:
                        link = "https://www.buscape.com.br/tv";
                        break;
                }
            } else if (typeSearch == (int)TypeProductSearch.ProductSerachMercadoLivre)
            {
                switch (category)
                {
                    case (int)TypeCategory.Mobile:
                        link = "https://lista.mercadolivre.com.br/casa-moveis-decoracao/moveis-casa/#deal_print_id=57e57770-e40c-11ed-a4d4-ab9d110a4556&c_id=carousel&c_element_order=4&c_campaign=BOLOTA_MOVEIS&c_uid=57e57770-e40c-11ed-a4d4-ab9d110a4556";
                        break;
                    case (int)TypeCategory.Refrigerator:
                        link = "https://lista.mercadolivre.com.br/eletrodomesticos/refrigeracao/";
                        break;
                    case (int)TypeCategory.TV:
                        link = "https://lista.mercadolivre.com.br/eletronicos-audio-video/televisores/#menu=categories";
                        break;

                }
            }
            return link;
        }
    }
}
