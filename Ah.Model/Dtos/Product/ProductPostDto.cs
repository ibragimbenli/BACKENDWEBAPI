using CommonTypesLayer.Model;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Model.Dtos.Product
{
    public class ProductPostDto : IDto
    {
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public int CategoryId { get; set; }
    }
}
