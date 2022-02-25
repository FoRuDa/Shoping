using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication :IArticleCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();

            if (_articleCategoryRepository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessage.Duplicate);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, command.Slug);
            var articleCategory = new ArticleCategory(command.Name, pictureName,command.PictureAlt,command.PictureTitle, command.Description,
                command.ShowOrder, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);
            
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);

            if (articleCategory == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (_articleCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, command.Slug);
            articleCategory.Edit(command.Name, pictureName, command.PictureAlt, command.PictureTitle, command.Description,
                command.ShowOrder, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);
            _articleCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel categorySearchModel)
        {
            return _articleCategoryRepository.Search(categorySearchModel);
        }
    }
}
