using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Interfaces;

namespace Ah.DataAccess.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        //Interface ile buraya CRUD işlemlerini getirdim...
        //CRUD işlemlerinin haricinde kullandığım metodlar aşağıda
        Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList);
        Task<List<Product>> GetProductsByStockAsync(short min, short max, params string[] includeList);
        Task<Product> GetByIdAsync(int productId, params string[] includeList);
    }
}
