using Loren_TPI_Prog3.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Loren_TPI_Prog3.Data.Entities
{
    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid OrderCode {  get; set; }
        public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
        public PaymentMethodEnum PaymentMethod {  get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
