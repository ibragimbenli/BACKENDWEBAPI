using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Interfaces;

namespace Ah.DataAccess.Interfaces
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        //Interface ile buraya CRUD işlemlerini getirdim...
        //CRUD işlemlerinin haricinde kullandığım metodlar aşağıda
        List<Product> GetByPriceRange(decimal min, decimal max);
        List<Product> GetProductsByStock(short min, short max);
        Product GetById(int productId);
    }
}
