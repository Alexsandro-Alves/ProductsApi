using ProductsApi.Common;

namespace ProductsApi.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}