using ErrorOr;
using Loren_TPI_Prog3.Data;
using Loren_TPI_Prog3.Data.Entities;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.Data.Models;
using Loren_TPI_Prog3.ServiceErrors;
using Loren_TPI_Prog3.Services.Interfaces;

namespace Loren_TPI_Prog3.Services.Implementations
{
    public class SaleOrderService : ISaleOrderService
    {
        private readonly LorenContext _context;
        public SaleOrderService( LorenContext context )
        {
            _context = context;
        }

        public ErrorOr<List<SaleOrder>> GetSaleOrdersByClient(int clientId)
        {
            return _context.SaleOrders.Where(so => so.ClientId == clientId).ToList();
        }

        public ErrorOr<List<SaleOrder>> GetSaleOrders()
        {
            return _context.SaleOrders.ToList();
        }

        public ErrorOr<decimal> CalculateLineTotal(int productId, int quantityOrdered)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
            decimal lineTotal = product.Price * quantityOrdered;
            return lineTotal;
        }

        public ErrorOr<decimal> CalculateSaleOrderTotal(List<SaleOrderLineCreateDto> saleOrderLines)
        {
            decimal saleOrderTotal = 0;
            foreach (SaleOrderLineCreateDto line in saleOrderLines)
            {
                saleOrderTotal += line.Total;
            }
            return saleOrderTotal;
        }

        public ErrorOr<int> CreateSaleOrder(SaleOrder saleOrder)
        {
            _context.Add(saleOrder);
            _context.SaveChanges();
            return saleOrder.Id;
        }

        public ErrorOr<Updated> CompleteSaleOrder(int saleOrderId)
        {
            SaleOrder saleOrder = _context.SaleOrders.SingleOrDefault(so => so.Id == saleOrderId);
            if (saleOrder == null)
            {
                return Errors.SaleOrder.NotFound;
            } else
            {
                if (saleOrder.Completed)
                {
                    return Errors.SaleOrder.AlreadyCompleted;
                } else
                {
                    saleOrder.Completed = true;
                    _context.Update(saleOrder);
                    _context.SaveChanges();
                    return Result.Updated;
                }
            }
        }

        public ErrorOr<Deleted> DeleteSaleOrder(int saleOrderId)
        {
            SaleOrder? saleOrder = _context.SaleOrders.SingleOrDefault(so => so.Id == saleOrderId);
            if (saleOrder == null)
            {
                return Errors.SaleOrder.NotFound;
            }
            else
            {
                if (!saleOrder.State)
                {
                    return Errors.SaleOrder.AlreadyDeleted;
                }
                else
                {
                    saleOrder.State = false;
                    _context.Update(saleOrder);
                    _context.SaveChanges();
                    return Result.Deleted;
                }
            }
        }
    }
}
