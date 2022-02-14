using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {

            var operation = new OperationResult();

            if (_articleRepository.Exist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.Duplicate);

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var article = new Article(command.Title, pictureName, command.PictureAlt, command.PictureTitle,
                command.ShortDescription,command.Description,
                command.PublishedDate.ToGeorgianDateTime(), slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId);
            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.GetWithCategorySlug(command.Id);

            if (article == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (_articleRepository.Exist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            var slug = command.Slug.Slugify();
            var path = $"{article.ArticleCategory.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, "");
            article.Edit(command.Title, pictureName, command.PictureAlt, command.PictureTitle,
                command.ShortDescription, command.Description,
                command.PublishedDate.ToGeorgianDateTime(), slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId);
        _articleRepository.SaveChanges();
        return operation.Success();

        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public string GetSlugBy(long id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
