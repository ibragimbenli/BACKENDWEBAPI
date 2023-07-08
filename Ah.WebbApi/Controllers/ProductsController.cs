using Ah.Business.Implementation;
using Ah.Business.Interface;
using Ah.DataAccess.EF.Context;
using Ah.Model.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public List<Product> GetProducts()
        {
            return _productBs.GetProducts();


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

        }
    }
}
