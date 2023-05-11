using Backend.Challenge.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Contracts
{
    /// <summary>
    ///
    /// </summary>
    public interface ICommentRepository : IRepository<CommentDto>
    {
        /// <summary>
        /// Get the page of comments.
        /// </summary>
        /// <param name="entityId">The entity Id.</param>
        /// <param name="skip">The number to skip.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns></returns>
        public IList<CommentDto> GetCommentPage(string entityId, int skip, int pageSize);
    }
}
