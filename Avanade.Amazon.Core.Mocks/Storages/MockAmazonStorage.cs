using Avanade.Amazon.Core.Entities;
using System.Collections.Generic;

namespace Avanade.Amazon.Core.DataAccessLayers.InMemory
{
    /// <summary>
    /// Database "in memory" for testing
    /// </summary>
    public class MockAmazonStorage
    {
        /// <summary>
        /// Books
        /// </summary>
        public IList<Book> Books { get; set; }

        /// <summary>
        /// Initializes storage with default data
        /// </summary>
        public MockAmazonStorage() 
        {
            //Inizializzo la lista dei libri vuota
            Books = new List<Book>();

            //Adesso aggiungo 3 libri in memoria
            Books.Add(new Book 
            {
                Id = "abc", 
                Title = "Il Signore degli Anelli", 
                Description = "bla bla bla", 
                Author = "JR Tolkien", 
                Publisher = "Mondadori", 
                Year = 2000
            });
            Books.Add(new Book
            {
                Id = "def",
                Title = "Le Due Torri",
                Description = "bla bla bla",
                Author = "JR Tolkien",
                Publisher = "Bompiani",
                Year = 2001
            });
            Books.Add(new Book
            {
                Id = "xyz",
                Title = "Il Ritorno del Re",
                Description = "bla bla bla",
                Author = "JR Tolkien",
                Publisher = "Rizzoli",
                Year = 2002
            });
        }
    }
}
