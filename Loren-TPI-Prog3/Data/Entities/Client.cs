namespace Loren_TPI_Prog3.Data.Entities
{
    public class Client : User
    {
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
