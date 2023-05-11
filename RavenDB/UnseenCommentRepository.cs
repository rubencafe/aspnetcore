using Backend.Challenge.Contracts;
using Backend.Challenge.Dtos;
using Backend.Challenge.RivenDB;
using Raven.Client.Documents.BulkInsert;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.RavenDB
{
    public class UnseenCommentRepository : RavenRepository<UnseenCommentDto>, IUnseenCommentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnseenCommentRepository"/> class.
        /// </summary>
        /// <param name="storeHolder">The document store holder.</param>
        public UnseenCommentRepository(IDocumentStoreHolder storeHolder) : base(storeHolder)
        {
        }

        public IEnumerable<string> GetAndRemove(string entityId, string userId)
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                var commentIds = session.Query<UnseenCommentDto>()
                    .Where(uc => uc.UserId.Equals(userId) && uc.EntityId.Equals(entityId))
                    .Select(uc => uc.CommentId)
                    .ToList();

                foreach (var commentId in commentIds)
                {
                    var entity = session.Load<UnseenCommentDto>(string.Concat(commentId, entityId, userId));
                    session.Delete(entity);
                }
                session.SaveChanges();
                return commentIds;
            }
        }

        public void Insert(IEnumerable<string> users, string commentId, string entityId)
        {
            using (BulkInsertOperation bulkInsert = _storeHolder.GetStore().BulkInsert())
            {
                foreach (var userId in users)
                {
                    bulkInsert.Store(new UnseenCommentDto
                    {
                        Id = string.Concat(commentId, entityId, userId),
                        UserId = userId,
                        EntityId = entityId,
                        CommentId = commentId
                    });
                }
            }
        }


    }
}
