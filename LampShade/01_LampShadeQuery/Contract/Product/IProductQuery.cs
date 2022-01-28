using System.Collections.Generic;

namespace _01_LampShadeQuery.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);
    }
}
