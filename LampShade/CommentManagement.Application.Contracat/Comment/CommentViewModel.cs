﻿namespace CommentManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Website { get; set; }
        public long OwnerRecordId { get; set; }
        public string OwnerName { get; set; }
        public int Type { get; set; }
        public bool Confirm { get;  set; }
        public bool Cancel { get;  set; }
        public string Message { get;  set; }
        public string CreationDate { get; set; }

    }
}