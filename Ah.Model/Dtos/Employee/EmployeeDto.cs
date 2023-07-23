using CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Model.Dtos.Employee
{
    public class EmployeeDto : IDto
    {
        public int FirstName { get; set; }
        public int City { get; set; }
    }
}
