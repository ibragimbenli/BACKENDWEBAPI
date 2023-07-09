using Ah.DataAccess.EF.Context;
using Ah.DataAccess.Interfaces;
using Ah.Model.Entities;
using CommonTypesLayer.DataAccess.Implementaitons.EF;
using System.Reflection.Metadata;

namespace Ah.DataAccess.EF.Repositoryies
{
    public class ProductRepository : BaseRepository<Product, NorthwndContext>, IProductRepository
    {
        public List<Product> GetByPriceRange(decimal min, decimal max)
        {
            var result = GetAll(prd => prd.UnitPrice < max && prd.UnitPrice > min);
            return result;
        }

        public List<Product> GetProductsByStock(short min, short max)
        {
            return GetAll(prd => prd.UnitsInStock > min && prd.UnitsInStock < max);
        }
    }
}
