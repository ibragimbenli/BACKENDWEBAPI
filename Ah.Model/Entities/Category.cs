using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Model.Entities
{
    public class Category:IEntitiy
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        //Navigator Property
        public List<Product>? Products { get; set; }
    }
}
