using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Loren_TPI_Prog3.Data.Models
{
    public class ProductVariantCreateDto
    {
        [ForeignKey("ColorId")]
        public ColorDto ColorDto { get; set; } 
        public int ColorId { get; set; }

        [ForeignKey("SizeId")]
        public SizeDto SizeDto { get; set; }
        public int SizeId { get; set; }
        public int Stock { get; set; }
     }
}
