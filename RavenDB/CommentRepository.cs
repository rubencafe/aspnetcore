using Backend.Challenge.Contracts;
using Backend.Challenge.Dtos;
using Backend.Challenge.RivenDB;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.RavenDB
{
    public class CommentRepository : RavenRepository<CommentDto>, ICommentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentRepository"/> class.
        /// </summary>
        /// <param name="storeHolder">The document store holder.</param>
        public CommentRepository(IDocumentStoreHolder storeHolder) : base(storeHolder)
        {
        }

        public IList<CommentDto> GetCommentPage(string entityId, int skip, int pageSize)
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                return session.Query<CommentDto>()
                    .Where(c => c.Entity.Equals(entityId))
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();
            }
        }
    }
}
