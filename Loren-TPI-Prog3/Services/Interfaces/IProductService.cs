using ErrorOr;
using Loren_TPI_Prog3.Data.Entities.Products;

namespace Loren_TPI_Prog3.Services.Interfaces
{
    public interface IProductService
    {
        public ErrorOr<Created> CreateProduct(Product product);
        public ErrorOr<Product> GetProduct(int productId);
        public ErrorOr<Updated> UpdateProduct(int productId, Product product);
        public ErrorOr<List<Product>> GetProducts();
        public ErrorOr<Deleted> DeleteProduct(int productId);
    }
}
