using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Slide
{
   public class CreateSlide
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }
        public string Heading { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }
        public string Text { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BtnText { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get; set; }
    }
}
