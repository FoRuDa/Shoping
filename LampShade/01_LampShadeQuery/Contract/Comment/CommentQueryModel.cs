namespace _01_LampShadeQuery.Contract.Comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public long PatentId { get; set; }
        public string ParentName { get; set; }
        public string CreationDate { get; set; }
    }
}