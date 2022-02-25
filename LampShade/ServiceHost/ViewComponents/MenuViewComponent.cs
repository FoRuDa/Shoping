using _01_LampShadeQuery;
using _01_LampShadeQuery.Contract.ArticleCategory;
using _01_LampShadeQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent :ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                ArticleCategories = _articleCategoryQuery.GetArticleCategories(),
                ProductCategories = _productCategoryQuery.GetProductCategoriesWithProduct()
        };

            return View(result);
        }
    }
}
