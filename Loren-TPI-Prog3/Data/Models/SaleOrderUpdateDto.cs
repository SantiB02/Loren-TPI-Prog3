using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Models
{
    public class SaleOrderUpdateDto
    {
        public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
        public PaymentMethodEnum PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
