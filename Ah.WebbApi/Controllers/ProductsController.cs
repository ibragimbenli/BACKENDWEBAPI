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
    public class ProductsController : ControllerBase
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
        public IActionResult GetById([FromRoute] int id)
        {
            var response = _productBs.GetById(id, "Category");


            return Ok(response);

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var response = _productBs.GetProducts("Category");

            if (response != null)
                return Ok(response.Data);

            return NotFound("Hiç Ürün Bulunamadı.");

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
        [HttpGet("getbyprice")]
        public IActionResult GetByPriceRange([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var dtoList = _productBs.GetProductsByPrice(min, max, "Category");

            if (dtoList != null)
            {

                return Ok(dtoList);
            }
            else
                return NotFound();
        }
        [HttpGet("getbystock")]
        public IActionResult GetProductsByStock(short min, short max)
        {
            var dtoList = _productBs.GetProductsByStock(min, max, "Category");

            if (dtoList != null)
            {
                return Ok(dtoList);
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult SaveNewProduct([FromBody] ProductPostDto dto)
        {
            if (dto == null)
                return BadRequest("Error: 'Gerekli veri gönderilmedi'");

            var insertedProduct = _productBs.Insert(dto);

            return CreatedAtAction(nameof(GetById), new { id = insertedProduct.ProductID }, insertedProduct);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductPutDto dto)
        {
            if (dto == null)
                return BadRequest("Error: 'Gerekli veri gönderilmedi'");

            _productBs.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            _productBs.Delete(id);

            return Ok();
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




