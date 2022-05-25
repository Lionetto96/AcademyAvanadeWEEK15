using Avanade.Amazon.Api.Tests;
using Avanade.Amazon.Core.BusinessLayers;
using Avanade.Amazon.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avanade.Amazon.Api.Controllers
{
    /// <summary>
    /// Controller for books management
    /// </summary>
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private MainBusinessLayer _Layer;

        public BooksController(MainBusinessLayer layer)
        {
            //Inizializzo le dipendenze
            _Layer = layer;
        }

        /// <summary>
        /// Fetch list of all books on storage
        /// </summary>
        /// <returns>Returns action result</returns>
        [HttpGet]
        [Route("FetchAll")]
        public IActionResult FetchAll()
        {
            //*** Compito 1: recuperare e validare gli input ricevuti dal client
            //In questo caso non devo fare nulla perchè non ho input

            //*** Compito 2: invocare il business layer per eseguire la funzione

            //Recupero l'elenco dei libri a catalogo
            IList<Book> entities = _Layer.FetchAllBooks();

            //*** Compito 3: produrre l'output da mandare al client

            //Semplicemente invio un 200-Ok con la lista di entities
            return Ok(entities);
        }

        /// <summary>
        /// Creates a new book on storage
        /// </summary>
        /// <param name="request">Request with data</param>
        /// <returns>Returns action result</returns>
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]CreateBookRequest request)
        {
            //*** Compito 1: recuperare e validare gli input ricevuti dal client

            //Validazione input
            if (request == null)
                return BadRequest();

            //Validazione dei campi
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //*** Compito 2: invocare il business layer per eseguire la funzione

            //Creo un oggetto Book usando i dati della request
            Book newBook = new Book
            {
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                Publisher = request.Publisher,
                Year = request.Year,
            };

            //Passo l'entity al business layer per l'archiviazione
            IList<ValidationResult> validations = _Layer.CreateBook(newBook);

            //*** Compito 3: produrre l'output da mandare al client

            //Se ho una sola validazione, la emetto con BadRequest
            if (validations.Count > 0)
                return BadRequest(validations);

            //Se è andato tutto bene, ritorno il libro creato
            return Ok(newBook);
        }
    }
}