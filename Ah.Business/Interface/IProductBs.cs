using Ah.Model.Dtos.Product;
using Ah.Model.Entities;
using CommonTypesLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Business.Interface
{
    public interface IProductBs
    {
        ApiResponse<List<ProductGetDto>> GetProducts(params string[] includeList);
        List<ProductGetDto> GetProductsByPrice(decimal min, decimal max, params string[] includeList);
        List<ProductGetDto> GetProductsByStock(short min, short max, params string[] includeList);
        ProductGetDto GetById(int productId, params string[] includeList);
        Product Insert(ProductPostDto entity);
        void Update(ProductPutDto entity);
        void Delete(int id);
    }
}
