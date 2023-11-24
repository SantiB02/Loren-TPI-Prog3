using ErrorOr;
using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Models;

namespace Loren_TPI_Prog3.Services.Interfaces
{
    public interface ISaleOrderService
    {
        public ErrorOr<List<SaleOrder>> GetSaleOrdersByClient(int clientId);
        public ErrorOr<List<SaleOrder>> GetSaleOrders();
        public ErrorOr<int> CreateSaleOrder(SaleOrder saleOrder);
        public ErrorOr<Updated> CompleteSaleOrder(int saleOrderId);
        public ErrorOr<Deleted> DeleteSaleOrder(int saleOrderId);
    }
}
