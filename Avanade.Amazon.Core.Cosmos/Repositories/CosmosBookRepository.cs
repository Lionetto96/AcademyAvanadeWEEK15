using Avanade.Amazon.Core.Cosmos.Utilities;
using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Avanade.Amazon.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avanade.Amazon.Core.Cosmos.Repositories
{
    /// <summary>
    /// Repository for Book on Cosmos driver
    /// </summary>
    public class CosmosBookRepository : IBookRepository
    {
        /// <summary>
        /// Database instance
        /// </summary>
        public IMongoDatabase Db { get; }

        /// <summary>
        /// Active collection
        /// </summary>
        public IMongoCollection<Book> Books { get; }

        /// <summary>
        /// Constructor (initializes database client)
        /// </summary>
        public CosmosBookRepository() 
        {
            //Creo una istanza di accesso al database
            Db = CosmosDbOptions.GetDatabase();

            //Creo l'istanza alla collezione di lavoro
            Books = Db.GetCollection<Book>("Books");
        }

        /// <summary>
        /// Fetch list of all entities
        /// </summary>
        /// <returns>Returns list</returns>
        public IList<Book> FetchAll()
        {
            //Creo un filtro vuoto => nella console di Robot3T "{}"
            var emptyFilter = FilterDefinition<Book>.Empty;

            //Applico il filtro e richiamo "ToList" per avviare l'estrazione
            return Books
                .Find(emptyFilter)
                .ToList();
        }

        /// <summary>
        /// Creates an entity on storage
        /// </summary>
        /// <param name="entityToCreate">Entity to create</param>       
        public void Create(Book entityToCreate)
        {
            //Validazione argomenti
            if (entityToCreate == null) throw new ArgumentNullException(nameof(entityToCreate));

            //Siccome abbiamo scelto di usare degli Id primary stringa
            //a scopo di passare la nostra piattaforma su Database Documentali
            //sono responsabile di creare un Guid come id primario
            entityToCreate.Id = Guid.NewGuid().ToString("D");

            //Eseguiamo un insert nel database
            Books.InsertOne(entityToCreate);
        }        
    }
}
