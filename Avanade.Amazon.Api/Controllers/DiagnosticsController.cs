using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Avanade.Amazon.Api.Controllers
{
    /// <summary>
    /// Controller for diagnostics
    /// </summary>
    [Route("api/[controller]")]
    public class DiagnosticsController: Controller
    {
        /// <summary>
        /// Echo for current application
        /// </summary>
        /// <returns>Returns application info</returns>
        [Route("")]
        public IActionResult Get() 
        {
            //Recupero il nome dell'applicazione
            var appName = Assembly.GetExecutingAssembly().GetName().Name;

            //Recupero la versione dell'applicazione
            var appVersion = 
                $"{Assembly.GetExecutingAssembly().GetName().Version.Major}." + 
                $"{Assembly.GetExecutingAssembly().GetName().Version.Minor}." +
                $"{Assembly.GetExecutingAssembly().GetName().Version.Build}";

            //Emetto una stringa con le informazioni
            return Content($"Application '{appName}' v.{appVersion} is running...");
        }
    }
}
