using ErrorOr;
using Loren_TPI_Prog3.Data;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.ServiceErrors;
using Loren_TPI_Prog3.Services.Interfaces;
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

        public ErrorOr<Deleted> DeleteProduct(Guid id)
        {
            Product? productToDelete = _context.Products.FirstOrDefault(p => p.Code == id);
            if (productToDelete == null)
            {
                return Errors.Product.NotFound;
            }
            productToDelete.State = false;
            _context.Products.Update(productToDelete);
            _context.SaveChanges();
            return Result.Deleted;
        }

        public ErrorOr<List<Product>> GetProducts()
        {
            return _context.Products.Where(p => p.State == true).ToList();
        }

        public ErrorOr<Product> GetProduct(Guid id)
        {
            Product? product = _context.Products.SingleOrDefault(p => p.Code == id);
            if (product != null)
            {
                return product;
            }
            return Errors.Product.NotFound;
        }

        public ErrorOr<Updated> UpdateProduct(Product product, Guid code)
        {
            if (_context.Products.SingleOrDefault(p => p.Code == code) != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Result.Updated;
            }
            return Errors.Product.NotFound;
        }

        //public ErrorOr<UpsertedProduct> UpsertProduct(Product product)
        //{
        //    var isNewlyCreated = !_products.ContainsKey(product.Code);
        //    _products[product.Code] = product;
        //    return new UpsertedProduct(isNewlyCreated);
        //}
    }
}
