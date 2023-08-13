using Ah.Business.Implementation;
using Ah.Business.Interface;
using Ah.DataAccess.ExtensionMetod;
using Ah.DataAccess.EF.Context;
using Ah.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ah.Model.Dtos.Product;
using CommonTypesLayer.Utilities;

namespace Ah.WebbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductBs _productBs;

        public ProductsController(IProductBs productBs)
        {
            _productBs = productBs;
        }


        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ProductGetDto>))]
        //[HttpGet("getbyId")]//([FromQuery])getbyId?id=5
        //([FromRoute])..api/products/7
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _productBs.GetByIdAsync(id, "Category");

            return SendResponse(response);
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productBs.GetProductsAsync("Category");

            return SendResponse(response);

            #region Klasik Yol
            //var products = _productBs.GetProducts("Category");

            //if (products.Count > 0)
            //{
            //    var productList = new List<ProductDto>();
            //    foreach (var product in products)
            //    {
            //        var dto = new ProductDto();
            //        dto.ProductName = product.ProductName;
            //        dto.CategoryName = product.Category.CategoryName;
            //        dto.UnitPrice = product.UnitPrice;
            //        dto.UnitsInStock = product.UnitsInStock;
            //        productList.Add(dto);
            //    }

            //    return Ok(productList);
            //}
            //else
            //    return NotFound(); 
            #endregion
            //StatusCodeResult
            //return NotFound();
            //return Ok();
            //return NoContent();
        }


        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet("getbyprice")]
        public async Task<IActionResult> GetByPriceRangeAsync([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _productBs.GetProductsByPriceAsync(min, max, "Category");
            return SendResponse(response);
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet("getbystock")]
        public async Task<IActionResult> GetProductsByStockAsync(short min, short max)
        {
            var response = await _productBs.GetProductsByStockAsync(min, max, "Category");
            return SendResponse(response);
        }


        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<ProductPostDto>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewProductAsync([FromBody] ProductPostDto dto)
        {
            var response = await _productBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.ProductID }, response.Data);
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductPutDto dto)
        {
            var response = await _productBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromQuery] int id)
        {
            var response = await _productBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}

//EF Linq Extentions Method
//var ctx = new NorthwndContext();
//var ProductList = ctx.Products.ToList();
//var ProductList = ctx.Products.Where(prd => prd.UnitPrice < 20).ToList();
//var ProductList = ctx.Products.Where(prd => prd.UnitPrice < 20 && prd.CategoryID == 2).ToList();
// var Prduct = ctx.Products.Single(prd => prd.CategoryID == 85);//Varlığından emin olduğum durumlarda kullanmalıyım eğer aradğım kiriterlerde ürün yoksa bana exeption fırlatır.
//var Prduct = ctx.Products.First(prd => prd.UnitPrice < 20);// Varlığından emin olduğum durumlarda kullanmalıyım eğer aradğım kiriterlerde ürün yoksa bana exeption fırlatır.
//var ProductList = ctx.Products.FirstOrDefault(prd =>prd.UnitPrice < 1); //varsa getir yoksa null döndür...
//var ProductList = ctx.Products.Select(...........);
//var ProductList = ctx.Products.Add();        
//var ProductList = ctx.Products.Update();
//var ProdcutList = ctx.Remove(productBs);
//var ProdcutList = ctx.Take(10); // sayfalama da ilk 10 ürünü getir
//var ProdcutList = ctx.Skip(10); // sayfalama da ilk 10 ürünü atla kalanını getir...
//                  Linq Select...

//sayfalama Örneği
//var ctx = new NorthwndContext();

//void sayfalama(int sayfaNo = 1, int displayCount = 1)
//{
//    var pageNumbber = sayfaNo;
//    var recordCount = displayCount;
//    ctx.Products.Skip((pageNumbber - 1) * recordCount).Take(pageNumbber);
//}
//ExtensionMetod Örnek
//var dolar = StringExtensions.ToDollar("1000",24.25M);
//Console.WriteLine(dolar);




