using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Avanade.Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avanade.Amazon.Core.BusinessLayers
{
    /// <summary>
    /// Main application business layer 
    /// with application logics
    /// </summary>
    public class MainBusinessLayer
    {
        private IBookRepository _BookRepository;

        public MainBusinessLayer(IBookRepository bookRepository)
        {
            //Inizializzo la variabile locale
            _BookRepository = bookRepository;
        }

        /// <summary>
        /// Fetch all books on storage
        /// </summary>
        /// <returns>Returns list of books</returns>
        public IList<Book> FetchAllBooks()
        {
            //Estrazione di tutto
            return _BookRepository.FetchAll();
        }

        /// <summary>
        /// Creates a book on storage after a successful validation
        /// </summary>
        /// <param name="newBook">New book</param>
        /// <returns>Returns validations of book</returns>
        public IList<ValidationResult> CreateBook(Book newBook)
        {
            //Validazione argomenti
            if (newBook == null) throw new ArgumentNullException(nameof(newBook));

            //Validazione dell'entity
            IList<ValidationResult> validations = ValidationUtils.Validate(newBook);

            //Se ho una sola validazione, esco e non faccio nulla
            if (validations.Count > 0)
                return validations;

            //Se invece arrivo qui, significa che posso chiedere
            //al DAL (al repository dei Book) di archiviare l'entity
            _BookRepository.Create(newBook);

            //Se arrivo qui e non ho errori, mando in uscita
            //una lista di validazioni vuota (ATTENZIONE! non nulla)
            return validations;
        }
    }
}