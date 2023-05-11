using System.Collections.Generic;

namespace Backend.Challenge.Contracts
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Insert a new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public string Insert(T entity);

        /// <summary>
        /// Update the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public void Update(T entity);

        /// <summary>
        /// Delete the entity.
        /// </summary>
        /// <param name="key">The entity key.</param>
        /// <returns></returns>
        public void Delete(string key);

        /// <summary>
        /// Get a list of entity taht contains key.
        /// </summary>
        /// <param name="key">The list of keys.</param>
        /// <returns></returns>
        public Dictionary<string, T> GetByKeys(IEnumerable<string> key);

        /// <summary>
        /// Get all documents of the collection.
        /// </summary>        
        /// <returns></returns>
        public IEnumerable<T> GetAll();
    }
}
