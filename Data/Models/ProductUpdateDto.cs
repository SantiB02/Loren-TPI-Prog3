using Loren_TPI_Prog3.Data.Entities.Products;

namespace Loren_TPI_Prog3.Data.Models
{
    public class ProductUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string ImageLink { get; set; }
        public string Category { get; set; }
    }
}
