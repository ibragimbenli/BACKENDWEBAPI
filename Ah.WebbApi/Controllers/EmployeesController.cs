using Ah.Business.Implementation;
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
        public async Task<IActionResult> GetAllEmployees()
        {
            //requesti clienttan aldıktan sonra kendi yapacaklarını burada yapacak sonra businessle haberleşecek...
            var employeeList = await _employeeBs.GetEmployees();
            if (employeeList.Count > 0)
                return Ok(employeeList);
            else return NotFound();
        }


    }
}
