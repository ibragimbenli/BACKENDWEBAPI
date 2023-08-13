using Ah.DataAccess.EF.Context;
using Ah.DataAccess.Interfaces;
using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Implementaitons.EF;
using System.Reflection.Metadata;

namespace Ah.DataAccess.EF.Repositoryies
{
    public class ProductRepository : BaseRepository<Product, NorthwndContext>, IProductRepository
    {
        public async Task<Product> GetByIdAsync(int productId,params string[] includeList)
        {
            //ctx.Products.SingleOrDefault(prd=>prd.ProductId== ProductId);
            var result = await GetAsync(prd => prd.ProductID == productId,includeList);
            return result;
        }

        public async Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {
            var result = await GetAllAsync(prd => prd.UnitPrice < max && prd.UnitPrice > min,includeList);
            return result;
        }

        public async Task<List<Product>> GetProductsByStockAsync(short min, short max , params string[] includeList)
        {
            return await GetAllAsync(prd => prd.UnitsInStock > min && prd.UnitsInStock < max,includeList);
        }
    }
}
