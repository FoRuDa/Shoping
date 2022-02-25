using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQuery.Contract.Article;
using _01_LampShadeQuery.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampShadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public ArticleCategoryQueryModel GetArticleCategoryBy(string slug)
        {
            var result =  _context.ArticleCategories.
                Include(x=>x.Articles)
                .Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                ArticleCount = x.Articles.Count,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                
                Articles = MapArticles(x.Articles),
                Slug = x.Slug,
            }).FirstOrDefault(x=>x.Slug==slug);

            if (result != null)
            {
                result.KeywordList = result.Keywords.Split(",").ToList();
            }

            return result;
            
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
            return articles.Select(x => new ArticleQueryModel
            {
                Title = x.Title,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                PublishedDate = x.PublishedDate.ToFarsi()
                
            }).ToList();
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _context.ArticleCategories.Include(x=>x.Articles)
                .Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ArticleCount = x.Articles.Count,

            }).OrderByDescending(x=>x.Id).Take(6).ToList();
        }
    }
}
