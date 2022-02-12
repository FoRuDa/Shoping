using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment:EntityBase
    {
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Confirm { get; private set; }
        public bool Cancel { get; private set; }
        public string Message { get; private set; }
        public Product Product { get; private set; }

        public Comment(long productId, string name, string email, string message)
        {
            ProductId = productId;
            Name = name;
            Email = email;
            Message = message;
            Confirm = false;
            Cancel = false;
        }

        public void Confirmed()
        {
            Confirm = true;
        }
        public void ConfirmedFalse()
        {
            Confirm = false;
        }
        public void Canceled()
        {
            Cancel = true;
        }
        public void CanceledFalse()
        {
            Cancel = false;
        }
    }
}
