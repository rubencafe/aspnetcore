using Backend.Challenge.Dtos;
using Backend.Challenge.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Challenge.Contracts
{
    public interface ICommentService
    {
        /// <summary>
        /// Create a comment.
        /// </summary>
        /// <param name="comment">The CommentDto.</param>       
        /// <returns></returns>
        public void CreateComment(CommentDto comment);

        /// <summary>
        /// Get the page of comments.
        /// </summary>
        /// <param name="entityId">The entity Id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns></returns>
        public GetCommentResponse GetCommentPage(string entityId, int page, int pageSize);

        /// <summary>
        /// Get new comments.
        /// </summary>
        /// <param name="entityId">The entity Id.</param>
        /// <param name="userId">The userId.</param>
        /// <returns></returns>
        public GetCommentResponse GetNewComments(string entityId, string userId);
    }
}
