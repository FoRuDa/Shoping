using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader,
            IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessage.Duplicate);

            var categorySlug = _productCategoryRepository.GetCategorySlugBy(command.CategoryId);
            var slug = command.Slug.Slugify();
            var path = $"{categorySlug}/{slug}";
            var picPath = _fileUploader.Upload(command.Picture, path);
            var product = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description,picPath, command.PictureAlt, command.PictureTitle,
                command.Keywords, command.MetaDescription, slug, command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetProductWithCategory(command.Id);

            if (product == null)
                return operation.Failed(ApplicationMessage.NotFound);
            if (_productRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            var slug = command.Slug.Slugify();
            var path = $"{product.Category.Slug}/{slug}";
            var picPath = _fileUploader.Upload(command.Picture,path);
            product.Edit(command.Name, command.Code, command.ShortDescription,
                command.Description,picPath , command.PictureAlt, command.PictureTitle,
                command.Keywords, command.MetaDescription, slug, command.CategoryId);
            _productRepository.SaveChanges();
            return operation.Success();
        }


        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetail(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}