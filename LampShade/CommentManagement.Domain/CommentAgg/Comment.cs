using System.Collections.Generic;
using _0_Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment:EntityBase
    {
        
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Website { get; private set; }
        public bool Confirm { get; private set; }
        public bool Cancel { get; private set; }
        public string Message { get; private set; }
        public long OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public long ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }
        public Comment(string name, string email,string website, string message, long ownerRecordId, int type,long parentId)
        {
            Name = name;
            Email = email;
            Website = website;
            Message = message;
            OwnerRecordId = ownerRecordId;
            Type = type;
            ParentId = parentId;
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
