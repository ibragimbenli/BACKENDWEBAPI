using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.DataAccess.Interfaces
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        //Interface ile buraya CRUD işlemlerini getirdim...
        //CRUD işlemlerinin haricinde kullandığım metodlar aşağıda
        List<Product> GetByPriceRange(decimal min, decimal max);
        List<Product> GetByStockRange(decimal min, decimal max);
    }
}
