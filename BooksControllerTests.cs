using Avanade.Amazon.Api.Controllers;
using Avanade.Amazon.Api.Tests.Utils;
using Avanade.Amazon.Core.BusinessLayers;
using Avanade.Amazon.Core.DataAccessLayers;
using Avanade.Amazon.Core.DataAccessLayers.InMemory;
using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Avanade.Amazon.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Avanade.Amazon.Api.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public void ShouldFetchAllBeOkWithAtLeastOneElement()
        {
            //USER STORY #2238: Come utente anonimo voglio poter vedere la lista dei libri presenti nel catalogo

            //BEHAVIOR: Chiamando la API che risponde all'indirizzo http://.../api/Books/FetchAll dovrei
            //ottenere un 200-OK (quindi una conferma) e il JSON risultante dovrebbe contenere almeno
            //un oggetto Book, e questo dovrebbe avere valorizzati i campi Title, Description, Author, Publisher
            //Year e basta!

            //*** ARRANGE (setup)

            //Inizializzo le dipendenze
            MockAmazonStorage storage = new MockAmazonStorage();
            IBookRepository dal = new MockBookRepository(storage);
            MainBusinessLayer layer = new MainBusinessLayer(dal);

            //Creazione di una istanza di controller (MVC)
            BooksController controller = new BooksController(layer);

            //*** ACT 

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            IActionResult result = controller.FetchAll();

            //*** ASSERT

            //Verifico che sia un 200-Ok ed estraggo una lista di libri
            IList<Book> books = ParseUtils.ExpectedOk<IList<Book>>(result);

            //Dovrebbe esserci almeno un oggetto nella lista
            Assert.True(books.Count > 0);

            //Dovrebbero esserci i campi stabiliti
            Assert.True(!string.IsNullOrEmpty(books[0].Id));
            Assert.True(!string.IsNullOrEmpty(books[0].Title));
            Assert.True(!string.IsNullOrEmpty(books[0].Description));
            Assert.True(!string.IsNullOrEmpty(books[0].Author));
            Assert.True(!string.IsNullOrEmpty(books[0].Publisher));
            Assert.True(books[0].Year > 0);
        }

        [Fact]
        public void ShouldCreateBeOkWithIncrementedElements() 
        {
            //USER STORY #2245: Come utente amministratore vorrei poter aggiungere un nuovo libro a catalogo

            //BEHAVIOR: Chiamando un endpoint api/Books/Create e passando una request con Title, 
            //Description, Author, Publisher, Year, dovrei ottere un 200-OK e avere nella risposta
            //un oggetto di tipo Book

            //*** ARRANGE

            //Inizializzo le dipendenze
            MockAmazonStorage storage = new MockAmazonStorage();
            IBookRepository dal = new MockBookRepository(storage);
            MainBusinessLayer layer = new MainBusinessLayer(dal);

            //Creazione di una istanza di controller (MVC)
            BooksController controller = new BooksController(layer);

            //Devo contare quanti libri ci sono nello storage PRIMA di creare
            var countBefore = storage.Books.Count;

            //Creazione di una request di esempio
            var request = new CreateBookRequest
            {
                Title = "Jurassic Park", 
                Description = "bla bla bla", 
                Author = "Michael Cricton", 
                Publisher = "Mondadori", 
                Year = 1996
            };

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            IActionResult result = controller.Create(request);

            //*** ASSERT

            //Verifico che sia un 200-Ok ed estraggo una lista di libri
            Book createdBook = ParseUtils.ExpectedOk<Book>(result);

            //Devo contare quanti libri ci sono nello storage DOPO aver creato
            var countAfter = storage.Books.Count;

            //Verifico che i record siano aumentati
            Assert.Equal(countBefore + 1, countAfter);

            //verifico che i dati dentro al libro siano coerenti con la richiesta
            Assert.Equal(request.Title, createdBook.Title);
            Assert.Equal(request.Description, createdBook.Description);
            Assert.Equal(request.Author, createdBook.Author);
            Assert.Equal(request.Publisher, createdBook.Publisher);
            Assert.Equal(request.Year, createdBook.Year);

            //L'entità creata deve avere un Id primario
            Assert.True(!string.IsNullOrEmpty(createdBook.Id));
        }
    }
}
