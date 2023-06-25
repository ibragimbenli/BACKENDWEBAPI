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
    public class ProductRepository : BaseRepository<Product, NorthwndContext>, IProductRepository
    {
        public List<Product> GetByPriceRange(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByStockRange(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }
    }
}
