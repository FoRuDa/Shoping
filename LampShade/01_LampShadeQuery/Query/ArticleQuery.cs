using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQuery.Contract.Article;
using BlogManagement.Infrastructure.EFCore;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery:IArticleQuery
    {
        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _context.Articles.Where(x => x.PublishedDate <= DateTime.Now).Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                PublishedDate = x.PublishedDate.ToFarsi(),
            }).Take(6).ToList();
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article =  _context.Articles.Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                CategorySlug = x.ArticleCategory.Slug,
                CategoryName = x.ArticleCategory.Name,
                PublishedDate = x.PublishedDate.ToFarsi(),
                CanonicalAddress = x.CanonicalAddress,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription
            }).FirstOrDefault(x => x.Slug == slug);

            article.KeywordList = article.Keywords.Split(",").ToList();
            return article;
        }
    }
}
