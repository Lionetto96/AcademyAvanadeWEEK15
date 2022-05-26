using Avanade.Amazon.Core.DataAccessLayers.InMemory;
using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Avanade.Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.Amazon.Core.DataAccessLayers
{
    /// <summary>
    /// Data access layer for entity Book with in memory provider
    /// </summary>
    public class MockBookRepository: IBookRepository
    {
        /// <summary>
        /// In memory storage
        /// </summary>
        public MockAmazonStorage Storage { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="storage">Dependency on storage</param>
        public MockBookRepository(MockAmazonStorage storage) 
        { 
            //Archivio la dipendenza nella proprietà locale
            Storage = storage;
        }

        /// <summary>
        /// Fetch all elements from storage
        /// </summary>
        /// <returns>Returns list of elements</returns>
        public IList<Book> FetchAll()
        {
            //Uso LINQ per l'estrazione in memoria
            return Storage.Books
                .OrderBy(b => b.Title)
                .ToList();
        }

        /// <summary>
        /// Creates entity on storage
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

            //Aggiunta alla lista
            Storage.Books.Add(entityToCreate);
        }
    }
}
