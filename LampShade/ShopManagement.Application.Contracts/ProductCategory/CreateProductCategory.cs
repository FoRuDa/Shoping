using System.ComponentModel.DataAnnotations;
using System.Security;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string Description { get;  set; }

        [FileExtensionLimitation(new string[]{".jpg",".jpeg",".png"},ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1 *1024 * 1024,ErrorMessage = "این فایل بیشتر از حجم مجاز میباشد.")]
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }


    }
}
