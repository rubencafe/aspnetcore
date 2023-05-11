using Backend.Challenge.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Contracts
{
    public interface IUnseenCommentRepository : IRepository<UnseenCommentDto>
    {
        /// <summary>
        /// Insert UnseenComment for users.
        /// </summary>
        /// <param name="users">The list of users.</param>
        /// <param name="commentId">The comment Id.</param>
        /// <param name="entityId">The entity Id.</param>
        /// <returns></returns>
        public void Insert(IEnumerable<string> users, string commentId, string entityId);

        /// <summary>
        /// Deletes and returns UnseenComments with entityId and userId.
        /// </summary>
        /// <param name="entityId">The entity Id.</param>
        /// <param name="userId">The user Id.</param>
        /// <returns></returns>
        public IEnumerable<string> GetAndRemove(string entityId, string userId);
    }
}