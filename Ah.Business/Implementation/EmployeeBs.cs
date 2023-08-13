using Ah.Business.Interface;
using Ah.DataAccess.Interfaces;
using Ah.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Business.Implementation
{
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeBs(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _repo.GetAllAsync();
            return employees;
        }
    }
}
