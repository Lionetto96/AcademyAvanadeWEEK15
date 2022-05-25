using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Entities
{
    //id, nome progetto, nome cliente
    public class Progetto
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
