    using System.Collections.Generic;
    using System.Linq;
    using _0_Framework.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using ShopManagement.Application.Contracts.Product;
    using ShopManagement.Domain.ProductAgg;

    namespace ShopManagement.Infrastructure.EFCore.Repository
    {
        public class ProductRepository :RepositoryBase<long,Product>,IProductRepository
        {
            private readonly ShopContext _context;
            public ProductRepository( ShopContext context) : base(context)
            {
                _context = context;
            }

          

            public EditProduct GetDetail(long id)
            {
                return _context.Products.Select(x=> new EditProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    Keywords = x.Keywords,
                    UnitPrice = x.UnitPrice,
                    CategoryId = x.CategoryId,
                    PictureAlt = x.PictureAlt,
                    Description = x.Description,
                    PictureTitle = x.PictureTitle,
                    MetaDescription = x.MetaDescription,
                    ShortDescription = x.ShortDescription,
                }).FirstOrDefault(x => x.Id == id);
            }

            public List<ProductViewModel> Search(ProductSearchModel searchModel)
            {
                var query = _context.Products.Include(x=>x.Category)
                    .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    UnitPrice = x.UnitPrice,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId,
                    Code = x.Code,
                    IsInStock = x.IsInStock,
                    CreationDate = x.CreationDate.ToString()
                });

                if (!string.IsNullOrWhiteSpace(searchModel.Name))
                    query = query.Where(x => x.Name.Contains(searchModel.Name));

                if (!string.IsNullOrWhiteSpace(searchModel.Code))
                    query = query.Where(x => x.Code.Contains(searchModel.Code));

                if (searchModel.CategoryId != 0)
                    query = query.Where(x => x.CategoryId == searchModel.CategoryId);

                return query.OrderByDescending(x => x.Id).ToList();

            }
        }
    }
