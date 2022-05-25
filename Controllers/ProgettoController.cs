using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgenziaConsulenzaAMM.API.Controllers
{
    [Route("api/[controller]")]
    public class ProgettoController : Controller
    {
        private BusinessLayer _Layer;

        public ProgettoController(BusinessLayer layer)
        {
            //Inizializzo le dipendenze
            _Layer = layer;
        }

        /// <summary>
        /// Fetch list of all books on storage
        /// </summary>
        /// <returns>Returns action result</returns>
        [HttpGet]
        [Route("FetchAll")]
        public IActionResult FetchAll()
        {
            
            IList<Progetto> entities = _Layer.FetchAllProjects();

            return Ok(entities);
        }
    }
}
