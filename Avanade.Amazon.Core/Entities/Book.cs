using System.ComponentModel.DataAnnotations;

namespace Avanade.Amazon.Core.Entities
{
    /// <summary>
    /// Entity for book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Primary identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Title of books
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [StringLength(4000)]
        public string Description { get; set; }

        /// <summary>
        /// Author (name and surname)
        /// </summary>
        [StringLength(255)]
        public string Author { get; set; }

        /// <summary>
        /// Publisher of books
        /// </summary>
        [StringLength(255)]
        public string Publisher { get; set; }

        /// <summary>
        /// Release year
        /// </summary>
        [Required]
        [Range(-3000, 3000)]
        public int Year { get; set; }
    }
}