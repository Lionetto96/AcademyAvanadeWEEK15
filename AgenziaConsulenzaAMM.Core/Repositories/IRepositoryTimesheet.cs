﻿using AgenziaConsulenzaAMM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Repositories
{
    public interface IRepositoryTimesheet
    {
        IList<Timesheet> FetchTimesheetsByProject(string IdProject);
    }
}