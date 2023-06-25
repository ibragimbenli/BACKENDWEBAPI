using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.DataAccess.Interfaces
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        //IBaseRepositoryden gelen CRUD diktesi var.

        //Haricen gerçekleştirmek istediğim metodu yazıyorum aşağıya
        List<Category> GetByDescription(string description);
    }
}
