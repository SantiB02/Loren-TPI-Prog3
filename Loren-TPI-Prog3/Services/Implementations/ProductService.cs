﻿using ErrorOr;
using Loren_TPI_Prog3.Data.Entities.Products;
using Loren_TPI_Prog3.ServiceErrors;
using Loren_TPI_Prog3.Services.Interfaces;

namespace Loren_TPI_Prog3.Services.Implementations
{
    public class ProductService : IProductService
    {
        private static readonly Dictionary<Guid, Product> _products = new();

        public ErrorOr<Created> CreateProduct(Product product)
        {
            _products.Add(product.Code, product);
            return Result.Created;

        }

        public ErrorOr<Deleted> DeleteProduct(Guid id)
        {
            _products.Remove(id);
            return Result.Deleted;
        }

        public ErrorOr<Product> GetProduct(Guid id)
        {
            if (_products.TryGetValue(id, out var product))
            {
                return product;
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
