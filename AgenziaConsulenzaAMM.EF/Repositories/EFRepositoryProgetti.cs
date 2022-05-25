using AgenziaConsulenzaAMM.Core.Entities;
using AgenziaConsulenzaAMM.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryProgetti : IRepositoryProgetto
    {
        /// <summary>
        /// Context for access EF
        /// </summary>
        private ContextDB Context { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EFRepositoryProgetti()
        {
            //Inizializzazione del contesto
            Context = new ContextDB();
        }

        /// <summary>
        /// return Timesheets ByIdProject
        /// </summary>
        /// <param name="IdProject"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>


        public IList<Progetto> FetchAllProject()
        {
            return Context.Projects
                .ToList();
        }
    }
}
