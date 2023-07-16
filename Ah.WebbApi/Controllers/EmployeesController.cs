using Ah.Business.Interface;
using Ah.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ah.WebbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBs _employeeBs;
        public EmployeesController(IEmployeeBs employeeBs)
        {
                _employeeBs = employeeBs;
        }
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            //requesti clienttan aldıktan sonra kendi yapacaklarını burada yapacak sonra businessle haberleşecek...
            var employeeList = _employeeBs.GetEmployees();
            return employeeList;
        }


    }
}
