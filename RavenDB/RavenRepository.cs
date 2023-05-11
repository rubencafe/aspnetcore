using Backend.Challenge.Contracts;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.RivenDB
{
    public abstract class RavenRepository<T> : IRepository<T> where T : class
    {
        protected readonly IDocumentStoreHolder _storeHolder;

        public RavenRepository(IDocumentStoreHolder storeHolder)
        {
            _storeHolder = storeHolder;
        }

        public void Delete(string key)
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                var entity = session.Load<T>(key);
                session.Delete(entity);
                session.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public Dictionary<string, T> GetByKeys(IEnumerable<string> keys)
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                return session.Load<T>(keys);
            }
        }

        public string Insert(T entity)
        {
            using (IDocumentSession session = _storeHolder.GetStore().OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
                return session.Advanced.GetDocumentId(entity);

            }
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
