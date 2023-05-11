using Raven.Client.Documents;

namespace Backend.Challenge.Contracts
{
    public interface IDocumentStoreHolder
    {
        /// <summary>
        /// Get document store.
        /// </summary>        
        /// <returns></returns>
        public IDocumentStore GetStore();
    }
}