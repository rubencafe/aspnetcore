using Backend.Challenge.Configuration;
using Backend.Challenge.Contracts;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Exceptions;
using Raven.Client.Exceptions.Database;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using System;

namespace Backend.Challenge.RavenDB
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private readonly Lazy<IDocumentStore> _store;

        private readonly RavenConfiguration _ravenConfiguration;

        public DocumentStoreHolder(IOptions<RavenConfiguration> configuration)
        {
            _ravenConfiguration = configuration.Value;
            _store = new Lazy<IDocumentStore>(new DocumentStore
            {
                Urls = new[] { _ravenConfiguration.ConnectionString },
                Database = _ravenConfiguration.DatabaseName
            }.Initialize());
            CreateDataBase();
        }

        public IDocumentStore GetStore()
        {
            return _store.Value;
        }

        private void CreateDataBase()
        {
            try
            {
                _store.Value.Maintenance.ForDatabase(_ravenConfiguration.DatabaseName).Send(new GetStatisticsOperation());
            }
            catch (DatabaseDoesNotExistException)
            {
                try
                {
                    _store.Value.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(_ravenConfiguration.DatabaseName)));
                }
                catch (ConcurrencyException)
                {
                    // The database was already created before calling CreateDatabaseOperation
                }
            }
        }
    }
}
