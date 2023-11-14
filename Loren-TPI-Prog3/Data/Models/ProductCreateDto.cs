using Loren_TPI_Prog3.Data.Entities.Products;

namespace Loren_TPI_Prog3.Data.Models
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<ProductVariantCreateDto> VariantsDto { get; set; }
        public decimal Price { get; set; }
    }
}
