using ErrorOr;
using Loren_TPI_Prog3.Data.Entities.Products;

namespace Loren_TPI_Prog3.Services.Interfaces
{
    public interface IProductService
    {
        ErrorOr<Created> CreateProduct(Product product);
        ErrorOr<Product> GetProduct(Guid id);
        ErrorOr<Updated> UpdateProduct(Product product, Guid code);
        ErrorOr<Deleted> DeleteProduct(Guid id);
        ErrorOr<IEnumerable<Product>> GetProducts();
    }
}
