using AgenziaConsulenzaAMM.Core.Entities;
using AgenziaConsulenzaAMM.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.BusinessLayer
{
    
    public class BusinessLayer
    {
        private IRepositoryEmployee _repositoryEmployee;
        private IRepositoryProgetto _repositoryProgetto;
        private IRepositoryTimesheet _repositoryTimesheet;

        public BusinessLayer(IRepositoryEmployee repositoryEmployee, IRepositoryProgetto repositoryProgetto, IRepositoryTimesheet repositoryTimesheet )
        {
            _repositoryEmployee = repositoryEmployee;
            _repositoryProgetto = repositoryProgetto;
            _repositoryTimesheet = repositoryTimesheet;
        }
        public IList<Timesheet> FetchTimesheetsByProject(string IdProject)
        {
            return _repositoryTimesheet.FetchTimesheetsByProject(IdProject);
        }


        public IList<Progetto> FetchAllProjects()
        {
            //Estrazione di tutto
            return _repositoryProgetto.FetchAllProject();
        }

        public IList<Employee> FetchAllEmployees()
        {
            //Estrazione di tutto
            return _repositoryEmployee.FetchAll();
        }
    }
}
