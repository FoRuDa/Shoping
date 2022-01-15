using System.Collections.Generic;
using System.Runtime.InteropServices;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discount.Colleague
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { set; get; }
        public ColleagueDiscountViewModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts;
        public SelectList Products;

        private readonly IColleagueDiscountApplication _ColleagueDiscountApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {
            _ColleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }


        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ColleagueDiscounts = _ColleagueDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()

        {
            var command = new DefineColleagueDiscount()
            {
                Products =new  SelectList(_productApplication.GetProducts(),"Id","Name")
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _ColleagueDiscountApplication.Define(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var colleagueDiscount = _ColleagueDiscountApplication.GetDetails(id);
            colleagueDiscount.Products = new SelectList(_productApplication.GetProducts(), "Id", "Name"); 
            return Partial("Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _ColleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _ColleagueDiscountApplication.Remove(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _ColleagueDiscountApplication.Restore(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

    }
}
