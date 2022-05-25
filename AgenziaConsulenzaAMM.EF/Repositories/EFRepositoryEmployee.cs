using AgenziaConsulenzaAMM.Core.Entities;
using AgenziaConsulenzaAMM.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryEmployee : IRepositoryEmployee
    {


       
            /// <summary>
            /// Context for access EF
            /// </summary>
            private ContextDB Context { get; }

            /// <summary>
            /// Constructor
            /// </summary>
            public EFRepositoryEmployee()
            {
                //Inizializzazione del contesto
                Context = new ContextDB();
            }

            /// <summary>
            /// Fetch all elements from storage
            /// </summary>
            /// <returns>Returns list of elements</returns>
            public IList<Employee> FetchAll()
            {
               
                return Context.Employees
                    .OrderBy(b => b.Nome)
                    .ToList();
            }
      
    }
}
