using Backend.Challenge.Contracts;
using Backend.Challenge.Dtos;
using Backend.Challenge.RivenDB;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.RavenDB
{
    public class UserRepository : RavenRepository<UserDto>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="storeHolder">The document store holder.</param>
        public UserRepository(IDocumentStoreHolder storeHolder) : base(storeHolder)
        {
        }

        public IList<UserDto> GetAllExcept(string userId)
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                return session.Query<UserDto>()
                    .Where(u => !u.Id.Equals(userId))
                    .ToList();
            }
        }
    }
}
