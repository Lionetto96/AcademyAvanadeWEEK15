using System.ComponentModel.DataAnnotations;

namespace Avanade.Amazon.Api.Tests
{
    /// <summary>
    /// Request for create new book
    /// </summary>
    public class CreateBookRequest
    {
        /// <summary>
        /// Title
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
        /// Author
        /// </summary>
        [StringLength(255)]
        public string Author { get; set; }

        /// <summary>
        /// Publisher
        /// </summary>
        [StringLength(255)]
        public string Publisher { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        [Required]
        [Range(-3000, 3000)]
        public int Year { get; set; }
    }
}