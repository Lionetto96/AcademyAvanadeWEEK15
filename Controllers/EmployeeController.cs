using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgenziaConsulenzaAMM.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private BusinessLayer _Layer;

        public EmployeeController(BusinessLayer layer)
        {
            //Inizializzo le dipendenze
            _Layer = layer;
        }


        /// <summary>
        /// Fetch list of all employees on storage
        /// </summary>
        /// <returns>Returns action result</returns>
        [HttpGet]
        [Route("FetchAll")]
        public IActionResult FetchAllEmployees()
        {
            //*** Compito 1: recuperare e validare gli input ricevuti dal client
            //In questo caso non devo fare nulla perchè non ho input

            //*** Compito 2: invocare il business layer per eseguire la funzione

            //Recupero l'elenco dei dipendenti 
            IList<Employee> entities = _Layer.FetchAllEmployees();

            //*** Compito 3: produrre l'output da mandare al client

            //Semplicemente invio un 200-Ok con la lista di entities
            return Ok(entities);
        }
    }
}
