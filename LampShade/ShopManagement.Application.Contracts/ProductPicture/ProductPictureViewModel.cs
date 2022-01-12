using System.Reflection.Metadata.Ecma335;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public string Picture { get; set; }
        public bool IsRemove { get; set; }
        public string CreationDate { get; set; }
    }
}