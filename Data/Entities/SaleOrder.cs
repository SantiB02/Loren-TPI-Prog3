using Loren_TPI_Prog3.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ErrorOr;
using Loren_TPI_Prog3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Loren_TPI_Prog3.Data.Entities
{
    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OrderCode {  get; set; }
        [Required]
        public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
        public PaymentMethodEnum PaymentMethod {  get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get { return this.CalculateSaleOrderTotal(); } } //NECESITA INCLUDE DE SALEORDERLINE CON SU PRODUCT AL MOMENTO DE CREAR UNA NUEVA SALEORDER PARA FUNCIONAR
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public bool Completed { get; set; } = false; //si es falso está en proceso, sino está completada
        public bool State { get; set; } = true; //para el borrado lógico. false está borrada

        private decimal CalculateSaleOrderTotal()
        {
            decimal saleOrderTotal = 0;
            foreach (SaleOrderLine line in SaleOrderLines)
            {
                decimal lineTotal = line.Product.Price * line.QuantityOrdered;
                saleOrderTotal += lineTotal;
            }
            return saleOrderTotal;
        }
    }
}
