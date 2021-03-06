using _01_LampShadeQuery.Contract.Product;
using CommentApplication.Infrastructure.EFCore;
using CommentManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);
        }

        public RedirectToPageResult OnPost(AddComment command,string productSlug)
        {
            command.Type = CommentType.Product;
            var result = _commentApplication.Create(command);
            return RedirectToPage("/product",new { Id = productSlug });
        }
    }
}
