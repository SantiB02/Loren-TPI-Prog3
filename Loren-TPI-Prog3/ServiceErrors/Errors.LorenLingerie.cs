using ErrorOr;

namespace Loren_TPI_Prog3.ServiceErrors
{
    public static class Errors
    {
        public static class Product
        {
            public static Error InvalidName => Error.Validation(
                code: "Product.InvalidName",
                description: $"The name must be between {Data.Entities.Product.MinNameLength} and {Data.Entities.Product.MaxNameLength} characters long."
            );
            public static Error InvalidDescription => Error.Validation(
           code: "Product.InvalidName",
           description: $"The name must be between {Data.Entities.Product.MinDescriptionLength} and {Data.Entities.Product.MaxDescriptionLength} characters long."
       );
            public static Error NotFound => Error.NotFound(
                code: "Product.NotFound",
                description: "The product was not found."
            );

        }
    }
}
