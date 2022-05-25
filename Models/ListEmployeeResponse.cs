using System.ComponentModel.DataAnnotations;

namespace AgenziaConsulenzaAMM.API.Models
{
    public class ListEmployeeResponse
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }
    }
}
