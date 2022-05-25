using AgenziaConsulenzaAMM.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgenziaConsulenzaAMM.API.Models
{
    public class ListTimesheetResponse
    {
        
        [Required]

        public double NumeroOre { get; set; }
        [Required]
        public DateTime DataTimesheet { get; set; }
        public string NameProject { get; set; }       
        public string NameEmployee { get; set; }
        
    }
}
