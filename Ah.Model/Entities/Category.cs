using CommonTypesLayer.Model;

namespace Ah.Model.Entities
{
    public class Category:IEntity
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        //Navigator Property
        public List<Product>? Products { get; set; }
    }
}
