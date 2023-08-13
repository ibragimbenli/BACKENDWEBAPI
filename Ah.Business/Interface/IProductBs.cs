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
        Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetProductsByPriceAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetProductsByStockAsync(short min, short max, params string[] includeList);
        Task<ApiResponse<ProductGetDto>> GetByIdAsync(int productId, params string[] includeList);
        Task<ApiResponse<Product>> InsertAsync(ProductPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
