using ErrorOr;
using Loren_TPI_Prog3.ServiceErrors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loren_TPI_Prog3.Data.Entities.Products
{
    public class Product
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 20;
        public const int MaxDescriptionLength = 150;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now; //fecha por defecto la actual
        public DateTime LastModifiedDate { get; set; } = DateTime.Now; //fecha por defecto la actual
        public ICollection<ProductVariant> Variants { get; set; }
        //public int Stock { get; set; } = 0; //si no se especifica, el stock por defecto es 0
        public decimal Price { get; set; }
        public bool State { get; set; } = true; //si no se especifica, el estado por defecto es true (activo)
        public Product() { } //constructor con 0 argumentos para permitir instanciar productos en el context


        private Product(
            Guid code,
            string name,
            string description,
            DateTime creationDate,
            DateTime lastModifiedDate,
            List<string> color,
            List<string> size
,
            bool state)
        {
            Code = code;
            Name = name;
            Description = description;
            CreationDate = creationDate;
            LastModifiedDate = lastModifiedDate;
            //Color = color;
            //Size = size;
            //Lean, revisar por qué dan error las dos asignaciones de arriba. color y size ya no son más listas, son clases separadas. Debe ser por eso.
        }

        public static ErrorOr<Product> Create(
            string name,
            string description,
            DateTime startDateTime,
            List<string> color,
            List<string> size,
            Guid? id = null,
            bool state = true //si no se especifica, el estado por defecto es true (activo)
        )
        {
            List<Error> errors = new();

            if (name.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Product.InvalidName);
            }
            if (description.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Product.InvalidDescription);
            }
            if (errors.Count > 0)
            {
                return errors;
            }
            return new Product(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            DateTime.UtcNow,
            color,
            size,
            state
        );
        }

        //public static ErrorOr<Product> From(CreateProductRequest request)
        //{
        //    return Create(
        //        request.Name,
        //        request.Description,
        //        request.StartDateTime,
        //        request.Color,
        //        request.Size
        //    );
        //}
        //public static ErrorOr<Product> From(Guid id, UpsertProductRequest request)
        //{
        //    return Create(
        //        request.Name,
        //        request.Description,
        //        request.StartDateTime,
        //        request.Color,
        //        request.Size,
        //        id
        //    );
        //}
    }
}
