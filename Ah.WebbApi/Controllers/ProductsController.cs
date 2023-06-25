using Ah.Business.Interface;
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
        }
    }
}
