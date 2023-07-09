using Ah.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Business.Interface
{
    public interface IProductBs
    {
        List<Product> GetProducts();
        List<Product> GetProductsByPrice(decimal min, decimal max);
        List<Product> GetProductsByStock(short min , short max);
        void Insert(Product entity);
    }
}
