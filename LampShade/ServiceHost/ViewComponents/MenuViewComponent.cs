using _01_LampShadeQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent :ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategories = _productCategoryQuery.GetProductCategoriesWithProduct();
            return View(productCategories);
        }
    }
}
