using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Entities.Products
{
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }
        public int SizeId { get; set; }
        public int Stock {  get; set; }
    }
}
