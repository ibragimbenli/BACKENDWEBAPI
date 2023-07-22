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
        List<Product> GetProducts(params string[] includeList);
        List<Product> GetProductsByPrice(decimal min, decimal max, params string[] includeList);
        List<Product> GetProductsByStock(short min, short max, params string[] includeList);
        Product GetById(int productId, params string[] includeList);
        void Insert(Product entity);
    }
}
