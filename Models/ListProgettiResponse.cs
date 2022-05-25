using System.ComponentModel.DataAnnotations;

namespace AgenziaConsulenzaAMM.API.Models
{
    public class ListProgettiResponse
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NameProject { get; set; }
        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }
    }
}
