using System.Collections.Generic;
using System.Runtime.InteropServices;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
   public  class ProductApplication :IProductApplication
   {
       private readonly IProductRepository _productRepository;

       public ProductApplication(IProductRepository productRepository)
       {
           _productRepository = productRepository;
       }

       public OperationResult Create(CreateProduct command)
       {
           var operation = new OperationResult();
           if (_productRepository.Exist(x => x.Name == command.Name))
               return operation.Failed(ApplicationMessage.Duplicate);
           var slug = command.Slug.Slugify();
           var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
               command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
               command.Keywords, command.MetaDescription, slug, command.CategoryId);
           _productRepository.Create(product);
           _productRepository.SaveChanges();
           return operation.Success();
       }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);

            if (product == null)
                return operation.Failed(ApplicationMessage.NotFound);
            if (_productRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                command.Keywords, command.MetaDescription, slug, command.CategoryId);
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult InStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed(ApplicationMessage.NotFound);

            product.InStock();
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed(ApplicationMessage.NotFound);

            product.NotInStock();
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