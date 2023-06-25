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
    public class CategoryRepository : BaseRepository<Category, NorthwndContext>, ICategoryRepository
    {
       //BaseRepositoryden CRUD işlemlerini Kalıtım yolu ile aldım.
        

        //Burada da ICagetoryRepositoryde dikte edilen harici metodu uyguladım.
        public List<Category> GetByDescription(string description)
        {
            throw new NotImplementedException();
        }
    }
}
