﻿using Ah.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Business.Interface
{
    public interface IEmployeeBs
    {
        List<Employee> GetEmployees();
    }
}
