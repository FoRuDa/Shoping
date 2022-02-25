using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampShadeQuery.Contract.Article;
using _01_LampShadeQuery.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel ArticleCategory;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        public List<ArticleQueryModel> Articles;
        
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly IArticleQuery _articleQuery;


        public ArticleCategoryModel(IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _articleQuery = articleQuery;
        }

        public void OnGet(string id)
        {
            ArticleCategory = _articleCategoryQuery.GetArticleCategoryBy(id);
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
            Articles = _articleQuery.LatestArticles(); 
        }
    }
}
