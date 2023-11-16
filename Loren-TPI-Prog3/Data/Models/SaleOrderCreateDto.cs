using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Models
{
    public class SaleOrderCreateDto
    {
        public ICollection<SaleOrderLineCreateDto> SaleOrderLines { get; set; } = new List<SaleOrderLineCreateDto>();
        public PaymentMethodEnum PaymentMethod { get; set; }
        public int ClientId { get; set; }
    }
}
