using Loren_TPI_Prog3.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Models
{
    public class SaleOrderLineCreateDto
    {
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public int SaleOrderId { get; set; }
    }
}
