using System.Collections.Generic;

namespace _01_LampShadeQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProductBy(string slug);
        List<ProductCategoryQueryModel> GetList();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProduct();
    }
}