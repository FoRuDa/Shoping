using System.Collections.Generic;
using _01_LampShadeQuery.Contract.Article;
using _01_LampShadeQuery.Contract.ArticleCategory;
using CommentApplication.Infrastructure.EFCore;
using CommentManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> ArticleCategories;

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Article = _articleQuery.GetArticleDetails(id);
            LatestArticles = _articleQuery.LatestArticles();
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
        }
        public RedirectToPageResult OnPost(AddComment command, string articleSlug)
        {
            command.Type = CommentType.Article;
            var result = _commentApplication.Create(command);
            return RedirectToPage("/article", new { Id = articleSlug });
        }
    }
}
