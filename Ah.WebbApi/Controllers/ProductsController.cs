using Ah.Business.Implementation;
using Ah.Business.Interface;
using Ah.DataAccess.ExtensionMetod;
using Ah.DataAccess.EF.Context;
using Ah.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ah.Model.Dtos.Product;

namespace Ah.WebbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBs _productBs;
        private readonly IMapper _mapper;
       
        public ProductsController(IProductBs productBs, IMapper mapper)
        {
            _productBs = productBs;
            _mapper = mapper;
        }
        //[HttpGet("getbyId")]//([FromQuery])getbyId?id=5
        [HttpGet("{id}")]//([FromRoute])..api/products/7
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productBs.GetById(id, "Category");

            if (product == null)
            {
                return NotFound();
            }
            else
            return Ok(product);
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productBs.GetProducts("Category");

            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductDto>>(products);
                //return Ok(_mapper.Map<List<ProductDto>>(products));

                return Ok(productList);
            }
            else
                return NotFound();

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
            var products = _productBs.GetProductsByPrice(min, max, "Category");

            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductDto>>(products);
                //return Ok(_mapper.Map<List<ProductDto>>(products));

                return Ok(productList);
            }
            else
                return NotFound();
        }
        [HttpGet("getbystock")]
        public IActionResult GetProductsByStock(short min, short max)
        {
            var products = _productBs.GetProductsByStock(min, max, "Category");

            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductDto>>(products);
                //return Ok(_mapper.Map<List<ProductDto>>(products));

                return Ok(productList);
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult SaveNewProduct(Product product)
        {
            if (product == null)
                return BadRequest("Error: 'Gerekli veri gönderilmedi'");
            _productBs.Insert(product);
            //return Created(nameof(GetProducts),product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductID }, product);
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




