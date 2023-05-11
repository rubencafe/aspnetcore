using Backend.Challenge.Contracts;
using Backend.Challenge.Dtos;
using Backend.Challenge.ServiceModels;
using System;
using System.Linq;

namespace Backend.Challenge.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnseenCommentRepository _unseenCommentRepository;
        private readonly IUserRepository _userRepository;


        public CommentService(
            ICommentRepository commentRepository,
            IUnseenCommentRepository unseenCommentRepository,
            IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _unseenCommentRepository = unseenCommentRepository;
            _userRepository = userRepository;
        }

        public void CreateComment(CommentDto comment)
        {
            comment.PublishedDate = DateTime.UtcNow;
            var otherUsers = _userRepository.GetAllExcept(comment.UserId).Select(u => u.Id);
            var commentId = _commentRepository.Insert(comment);
            _unseenCommentRepository.Insert(otherUsers, commentId, comment.Entity);
        }

        public GetCommentResponse GetCommentPage(string entityId, int page, int pageSize)
        {
            return new GetCommentResponse
            {
                Comments = _commentRepository.GetCommentPage(entityId, page * pageSize, pageSize)
            };
        }

        public GetCommentResponse GetNewComments(string entityId, string userId)
        {
            var commentIds = _unseenCommentRepository.GetAndRemove(entityId, userId);
            var comments = _commentRepository.GetByKeys(commentIds);
            return new GetCommentResponse
            {
                Comments = comments.Values.ToList()
            };
        }
    }
}
