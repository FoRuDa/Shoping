using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Comments
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { set; get; }
        public List<CommentViewModel> Comments;
        public CommentSearchModel SearchModel;
        public SelectList Products;

        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {
            Comments = _commentApplication.Search(searchModel);
        }

        public IActionResult OnGetConfirm(long id)
        {
           var result = _commentApplication.Confirm(id);
           if (result.IsSuccess)
               return RedirectToPage("./index");
           Message = result.Message;
           return RedirectToPage("./index");
        }

        public IActionResult OnGetCancel(long id)
        {
            var result = _commentApplication.Cancel(id);
            if (result.IsSuccess)
                return RedirectToPage("./index");
            Message = result.Message;
            return RedirectToPage("./index");
        }
    }
}
