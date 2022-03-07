using System.Collections.Generic;
using _0_Framework.Application;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;

namespace CommentManagement.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Create(AddComment command)
        {
            var operation = new OperationResult();

            if (command == null)
                return operation.Failed(ApplicationMessage.NotFound);

            var comment = new Comment( command.Name, command.Email, command.Website,command.Message,command.OwnerRecordId,command.Type,command.ParentId);
            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);

            if (comment == null)
                return operation.Failed(ApplicationMessage.NotFound);
            comment.Confirmed();
            comment.CanceledFalse();
            _commentRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);

            if (comment == null)
                return operation.Failed(ApplicationMessage.NotFound);
            comment.Canceled();
            comment.ConfirmedFalse();
            _commentRepository.SaveChanges();
            return operation.Success();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _commentRepository.Search(searchModel);
        }
    }
}
