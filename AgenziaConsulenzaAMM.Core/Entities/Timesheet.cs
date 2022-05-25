using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Entities
{
    public class Timesheet
    {
        public string Id { get; set; }
        [Required]
        
        public double NumeroOre { get; set; }
        [Required]
        public DateTime DataTimesheet { get; set; }
        public Progetto Progetto { get; set; }

        public string IdProject { get; set; }
        public Employee Employee { get; set; }
        public string  IdEmployee  { get; set; }
    }
}
