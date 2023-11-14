using Loren_TPI_Prog3.Data.Entities.Products;

namespace Loren_TPI_Prog3.Data.Models
{
    public class ProductUpdateDto
    {
        public Guid Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
