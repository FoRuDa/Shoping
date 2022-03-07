using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampShadeQuery.Contract.Article;
using _01_LampShadeQuery.Contract.Comment;
using BlogManagement.Infrastructure.EFCore;
using CommentApplication.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery:IArticleQuery
    {
        private readonly BlogContext _context;
        private readonly CommentContext _commentContext;
        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
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
                MetaDescription = x.MetaDescription,
            }).FirstOrDefault(x => x.Slug == slug);

            if (article != null)
            {
                article.KeywordList = article.Keywords.Split(",").ToList();
            }

            if (article != null)
            {
                article.Comments = _commentContext.Comments
                    .Where(x => x.Type == CommentType.Article)
                    .Where(x => x.OwnerRecordId == article.Id)
                    .Where(x => !x.Cancel).Where(x => x.Confirm)
                    .Include(x=>x.Parent)
                    .Select(x => new CommentQueryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Message = x.Message,
                        PatentId = x.ParentId,
                        ParentName = x.Parent.Name,
                        CreationDate = x.CreationDate.ToFarsi()
                    }).OrderByDescending(x => x.Id).ToList();
            }

            return article;
            
        }
    }
}
