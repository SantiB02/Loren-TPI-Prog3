using ErrorOr;
using Loren_TPI_Prog3.Data;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.ServiceErrors;
using Loren_TPI_Prog3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Loren_TPI_Prog3.ServiceErrors.Errors;
using Product = Loren_TPI_Prog3.Data.Entities.Products.Product;

namespace Loren_TPI_Prog3.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly LorenContext _context;
        public ProductService(LorenContext context)
        {
            _context = context;
        }

        public ErrorOr<Created> CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Result.Created;
        }

        public ErrorOr<List<Product>> GetProducts()
        {
            return _context.Products
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Size)
                .Where(p => p.State == true)
                .ToList();
        }

        public ErrorOr<Product> GetProduct(int productId)
        {
            Product? product = _context.Products.SingleOrDefault(p => p.Id == productId);
            if (product != null)
            {
                return product;
            }
            return Errors.Product.NotFound;
        }

        public ErrorOr<Updated> UpdateProduct(int productId, Product product)
        {
            if (_context.Products.SingleOrDefault(p => p.Id == productId) != null)
            {
                _context.ChangeTracker.Clear(); //NO TOCAR
                _context.Products.Update(product);
                _context.SaveChanges();
                return Result.Updated;
            }
            return Errors.Product.NotFound;
        }

        public ErrorOr<Deleted> DeleteProduct(int productId)
        {
            Product? product = _context.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return Errors.Product.NotFound;
            }
            else
            {
                if (!product.State)
                {
                    return Errors.Product.AlreadyDeleted;
                }
                else
                {
                    product.State = false;
                    _context.Update(product);
                    _context.SaveChanges();
                    return Result.Deleted;
                }
            }
        }
    }
}
