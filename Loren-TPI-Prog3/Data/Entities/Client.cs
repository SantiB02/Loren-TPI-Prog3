namespace Loren_TPI_Prog3.Data.Entities
{
    public class Client : User
    {
        public string Address { get; set; }
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
