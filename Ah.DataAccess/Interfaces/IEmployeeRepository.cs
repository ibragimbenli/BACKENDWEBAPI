using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        //GetByCity(string city)
        Task<List<Employee>> GetByCity(string city);
        //GetByAgeRange(int age)
        Task<List<Employee>> GetByAgeRange(int min, int max);
    }
}
