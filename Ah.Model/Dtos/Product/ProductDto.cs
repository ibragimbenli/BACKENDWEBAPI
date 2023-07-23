using CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Model.Dtos.Product
{
    public class ProductDto : IDto
    {
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? CategoryName { get; set; }

    }
}
