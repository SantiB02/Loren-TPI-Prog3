﻿using Loren_TPI_Prog3.Data.Entities.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Entities
{
    public class SaleOrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal Total { get { return Product.Price * QuantityOrdered; } } //No se guarda en la base de datos, cálc. simple
        [ForeignKey("SaleOrderId")]
        public int SaleOrderId { get; set; }
    }
}
