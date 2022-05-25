using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgenziaConsulenzaAMM.API.Controllers
{
    [Route("api/[controller]")]
    public class TimesheetController : Controller
    {
        private BusinessLayer _Layer;

        public TimesheetController(BusinessLayer layer)
        {
            //Inizializzo le dipendenze
            _Layer = layer;
        }

        /// <summary>
        /// Fetch list of all timesheet By IdProject
        /// </summary>
        /// <returns>Returns action result</returns>
        [HttpGet]
        [Route("FetchTimesheetById")]
        public IActionResult FetchTimesheetByIdProject(string idProject)
        {
            
            IList<Timesheet> entities =_Layer.FetchTimesheetsByProject(idProject) ;

            
            return Ok(entities);
        }
    }
}
