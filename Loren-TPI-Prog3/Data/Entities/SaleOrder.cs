namespace Loren_TPI_Prog3.Data.Entities
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public ICollection<Product> ProductsOrdered { get; set; } = new List<Product>();
        public pay
    }
}
