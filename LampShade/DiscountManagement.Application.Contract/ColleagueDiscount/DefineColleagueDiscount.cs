using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        [Range(1,100000,ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }
        public SelectList Products { get; set; }
    }
}
