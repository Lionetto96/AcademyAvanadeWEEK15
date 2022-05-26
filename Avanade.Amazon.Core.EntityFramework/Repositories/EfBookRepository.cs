using Avanade.Amazon.Core.DataAccessLayers.Contexts;
using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Avanade.Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.Amazon.Core.DataAccessLayers
{
    /// <summary>
    /// Repository for table "Books" using EntityFramework
    /// </summary>
    public class EfBookRepository : IBookRepository
    {
        /// <summary>
        /// Context for access EF
        /// </summary>
        private AmazonDbContext Context { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EfBookRepository()
        {
            //Inizializzazione del contesto
            Context = new AmazonDbContext();
        }

        /// <summary>
        /// Fetch all elements from storage
        /// </summary>
        /// <returns>Returns list of elements</returns>
        public IList<Book> FetchAll()
        {
            //Estrazione di tutti i libri ordinati per Title
            // => SELECT * FROM Books ORDER BY Title
            return Context.Books
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

            //Aggiungo l'entità al DbSet
            Context.Books.Add(entityToCreate);

            //Eseguo il savechanges per archiviare i dati sul database
            Context.SaveChanges();
        }
    }
}