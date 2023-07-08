using Ah.DataAccess.EF.Context;
using Ah.DataAccess.Interfaces;
using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Implementaitons.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.DataAccess.EF.Repositoryies
{
    public class EmployeeRepository : BaseRepository<Employee, NorthwndContext>, IEmployeeRepository
    {
        public List<Employee> GetByAgeRange(int min, int max)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByCity(string city)
        {
            throw new NotImplementedException();
        }
    }
}
